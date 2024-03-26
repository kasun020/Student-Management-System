namespace StudentManagementSystem.entities
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }
        
        public string Password { get; set; }
        
        public string FullName { get; set; }
        
        public string RegNum { get; set; }
        
        public string ImagePath { get; set; }
        
        public byte[] ImageData { get; set; }
    }
}