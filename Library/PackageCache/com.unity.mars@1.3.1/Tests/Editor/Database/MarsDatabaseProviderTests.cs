#if UNITY_EDITOR
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;
using Unity.MARS.Query;
using Unity.XRTools.ModuleLoader;

namespace Unity.MARS.Data.Tests
{
#pragma warning disable 67
    class MarsDatabaseProviderTests
    {
        const int k_ExampleTraitId = 42;

        MARSDatabase m_Db;

        Dictionary<int, MRPlane> m_TempPlanes = new Dictionary<int, MRPlane>();
        Dictionary<int, MRReferencePoint> m_TempReferencePoints = new Dictionary<int, MRReferencePoint>();
        Dictionary<int, IMRFace> m_TempFaces = new Dictionary<int, IMRFace>();

        MARSDataProvider<Vector4> m_Vector4Provider = new MARSDataProvider<Vector4>();

        static readonly Vector4 k_ExampleVectorValue = new Vector4(1f, 2f, 4f, 8f);

        [OneTimeSetUp]
        public void Setup()
        {
            m_Db = new MARSDatabase();
            var dbModule = (IModule)m_Db;
            dbModule.LoadModule();
        }

        [Test]
        public void AddGenericDataReturnsId()
        {
            var dataId = m_Vector4Provider.AddData(k_ExampleVectorValue);
            Assert.AreEqual(dataId, MARSDatabase.nextDataID - 1);
        }

        [Test]
        public void GenericDataAddUpdateRetrieve()
        {
            var dataId = m_Vector4Provider.AddData(k_ExampleVectorValue);
            Assert.AreEqual(dataId, MARSDatabase.nextDataID - 1);
            var newValue = new Vector4(0.5f, 1f, 2f, 4f);
            Assert.True(m_Vector4Provider.UpdateData(dataId, newValue));
            var retrievedValue = m_Vector4Provider.GetIdValue(dataId);
            Assert.AreEqual(newValue, retrievedValue);
        }

        [Test]
        public void GenericDataAddRemove()
        {
            var dataId = m_Vector4Provider.AddData(k_ExampleVectorValue);
            Assert.True(m_Vector4Provider.RemoveData(dataId));
            Assert.False(m_Vector4Provider.UpdateData(dataId, new Vector4()));
        }

        [Test]
        public void EnumerateGenericData()
        {
            var startingCount = m_Vector4Provider.Count;
            m_Vector4Provider.AddData(k_ExampleVectorValue);
            m_Vector4Provider.AddData(new Vector4(0.5f, 1f, 2f, 4f));

            Assert.AreEqual(m_Vector4Provider.Count, startingCount + 2);
            foreach (var kvp in m_Vector4Provider.GetCollection())
            {
                  Assert.IsInstanceOf<int>(kvp.Key);
                  Assert.IsInstanceOf<Vector4>(kvp.Value);
            }
        }

        [Test]
        public void AddMRPlaneData()
        {
            var plane = new MRPlane();
            plane.id = MarsTrackableId.Create();
            plane.pose = new Pose(Vector3.up, Quaternion.identity);
            plane.extents = new Vector2(0.5f, 1f);

            m_Db.planeData.AddOrUpdateData(plane);
            m_Db.planeData.GetAllData(m_TempPlanes);

            Assert.AreEqual(1, m_TempPlanes.Count);
        }

        [Test]
        public void AddMARSReferencePointData()
        {
            var point1 = new MRReferencePoint(new Pose(Vector3.right, Quaternion.identity));
            point1.id = MarsTrackableId.Create();
            var point2 = new MRReferencePoint(new Pose(Vector3.up, Quaternion.identity));
            point2.id = MarsTrackableId.Create();

            // this will probably need to change when we change how we generate IDs
            var marsDataId1 = m_Db.referencePointData.AddOrUpdateData(point1);
            var marsDataId2 = m_Db.referencePointData.AddOrUpdateData(point2);

            m_Db.referencePointData.GetAllData(m_TempReferencePoints);
            Assert.AreEqual(2, m_TempReferencePoints.Count);

            Assert.True(m_TempReferencePoints.TryGetValue(marsDataId1, out point1));
            Assert.True(m_TempReferencePoints.TryGetValue(marsDataId2, out point1));
        }

        [Test]
        public void AddMRFaceData()
        {
            var face = new TestFace { pose = new Pose(Vector3.forward, Quaternion.identity) };
            face.id = MarsTrackableId.Create();

            m_Db.faceData.AddOrUpdateData(face);
            m_Db.faceData.GetAllData(m_TempFaces);
            Assert.AreEqual(1, m_TempFaces.Count);
        }

        public void AddGetRemove_TraitValue<T>(int id, string traitName, T traitValue)
        {
            var provider = new MARSTraitDataProvider<T>(dataId => { }, m_Db);
            provider.AddOrUpdateTrait(id, traitName, traitValue);

            T retrievedValue;
            provider.TryGetTraitValue(id, traitName, out retrievedValue);
            Assert.AreEqual(traitValue, retrievedValue);

            Assert.True(provider.RemoveTrait(id, traitName));

            T postRemovalValue;
            Assert.False(provider.TryGetTraitValue(id, traitName, out postRemovalValue));
            Assert.AreEqual(default(T), postRemovalValue);
        }

        [Test]
        public void AddGetRemoveSemanticTagTraitValue()
        {
            m_Db.GetTraitProvider(out MARSTraitDataProvider<bool> tagTraits);
            AddGetRemove_TraitValue(k_ExampleTraitId, TraitNames.Floor, true);
        }

        [Test]
        public void AddGetRemoveIntTraitValue()
        {
            AddGetRemove_TraitValue(k_ExampleTraitId, "dogs.count", 24);
        }

        [Test]
        public void AddGetRemoveFloatTraitValue()
        {
            AddGetRemove_TraitValue(k_ExampleTraitId, "temp.celsius", 20.02f);
        }

        [Test]
        public void AddGetRemoveVector2TraitValue()
        {
            AddGetRemove_TraitValue(k_ExampleTraitId, "myroom.size", Vector2.down);
        }

        [Test]
        public void AddGetRemoveVector3TraitValue()
        {
            AddGetRemove_TraitValue(k_ExampleTraitId, "wind.direction", Vector3.up);
        }

        [Test]
        public void AddGetRemoveStringTraitValue()
        {
            AddGetRemove_TraitValue(k_ExampleTraitId, "city.name", "San Francisco");
        }

        [Test]
        public void AddGetRemovePoseTraitValue()
        {
            var traitValue = new Pose(Vector3.up + Vector3.right, Quaternion.identity);
            m_Db.GetTraitProvider(out MARSTraitDataProvider<Pose> provider);
            const string traitName = "book.pose";

            provider.AddOrUpdateTrait(k_ExampleTraitId, traitName, traitValue);

            Pose retrievedValue;
            provider.TryGetTraitValue(k_ExampleTraitId, traitName, out retrievedValue);
            Assert.AreEqual(traitValue, retrievedValue);

            Assert.True(provider.RemoveTrait(k_ExampleTraitId, traitName));

            Pose postRemovalValue;
            Assert.False(provider.TryGetTraitValue(k_ExampleTraitId, traitName, out postRemovalValue));

            var newPose = new Pose();
            Assert.AreEqual(newPose.position, postRemovalValue.position);
            Assert.AreEqual(newPose.rotation, postRemovalValue.rotation);
        }
    }
#pragma warning restore 67
}
#endif
