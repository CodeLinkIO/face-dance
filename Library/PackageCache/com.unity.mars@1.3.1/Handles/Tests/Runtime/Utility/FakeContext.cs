using UnityEngine;

namespace Unity.MARS.MARSHandles.Tests
{
    sealed class FakeContext : RuntimeHandleContext
    {
        readonly InteractionState m_Interaction;

        public FakeContext()
        {
            m_Interaction = new InteractionState(this);
        }

        public void SetHover(InteractiveHandle handle)
        {
            m_Interaction.SetHovered(handle);
        }

        public void DoDragStart()
        {
            m_Interaction.StartDrag(new Vector3(0, 0, 100));
        }

        public void DoDragStop()
        {
            m_Interaction.StopDrag();
        }

        public void Update()
        {
            m_Interaction.Update(new Vector3(0, 0, 100));
        }
    }
}