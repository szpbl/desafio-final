namespace bibliotecaAPI.Models
{
    public class Role
    {
        #region Properties

        public int Id { get; set; }
        public string Name { get; set; }

        #endregion


        #region Constructor

        public Role(int id, string name)
        {
            Id = id;
            Name = name;
        }

        #endregion

    }
}
