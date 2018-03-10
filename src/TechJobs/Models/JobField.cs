namespace TechJobs.Models
{
    public class JobField
    {   // Each Individual subClass have thier own , string Value and int ID
        // And Method
        public int ID { get; set; }
        private static int nextId = 1;

        public string Value { get; set; }

        public JobField()
        {
            ID = nextId;
            nextId++;
        }
        // Method Extension
        public JobField(string value) : this()
        {
            Value = value;
        }

        // Provide a basic case-insensitive search
        public bool Contains(string testValue)
        {
            return Value.ToLower().Contains(testValue.ToLower());
        }
        // We store Field as Object because The value have duplicate 
        // storing as string would mean a new mem location is create
        // by storing as an Object later on Value would refernce the object instead
        // i.e. only one instance is created
        // We override the ToString Method so that when called it woud return 
        // the requested Value instead of the inherited action from the Base Object Class
        // Object.ToString() return the Type VS primitive Type converting into string.
        // Further by referencing a single Object incase of Error we can simultaneouly
        // change all the "Value" a once. Evenmore by using Object vs String we can add more
        // properties when the need rised. ex. Employer have Address and Sector 
        // i.e GM/Ford = Auto BAC/JP Morgan = Financial
        public override string ToString()
        {
            return Value;
        }

        // override object.Equals
        public override bool Equals(object obj)
        {

            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            
            return (obj as JobField).ID == ID;
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return ID;
        }

    }
}
