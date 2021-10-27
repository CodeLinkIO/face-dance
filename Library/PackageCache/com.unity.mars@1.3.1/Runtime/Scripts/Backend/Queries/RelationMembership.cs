namespace Unity.MARS.Query
{
    struct RelationMembership
    {
        /// <summary>An index into the relation rating results for a single Set </summary>
        public int RelationIndex;
        /// <summary> Which member of the relation is this context ? if false, it is member 2</summary>
        public bool FirstMember;

        public RelationMembership(int index, bool firstMember)
        {
            RelationIndex = index;
            FirstMember = firstMember;
        }
    }
}
