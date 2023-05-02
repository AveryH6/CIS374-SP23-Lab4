

namespace Lab4
{
    public class PersonGroup
    {
        public List<Person> Persons { get; set; } = new List<Person>();

        public char? StartingLetter {
            get {
                // if Persons is SORTED
                return Persons[0].FirstName[0];
            }
        }

        // TODO
        public char? EndingLetter
        {
            get
            {
                return Persons[Count - 1].FirstName[Count - 1];
            }
        }

        public int Count => Persons.Count;

        public Person this[int i]
        {
            get
            {
                if (Persons == null)
                    throw new NullReferenceException("Persons is null");

                if (i < 0 || i > Persons.Count)
                    throw new IndexOutOfRangeException();

                Persons.Sort();
                return Persons[i];
            }
        }

        public PersonGroup(List<Person> persons = null)
        {
            if( persons != null)
            {
                foreach(var p in persons)
                {
                    Persons.Add(p);
                }
            }

            Persons.Sort();
        }

        public override string ToString()
        {
            return "[" + String.Join(", ", Persons)+ "]";
        }


        // TODO
        public static List<PersonGroup> GeneratePersonGroups(List<Person> persons, int distance)
        {
            List<PersonGroup> personGroups = new List<PersonGroup>();

            // This isn't correct code. 
            // It's is just a sample of how to interact with the classes.
            //var group1 = new PersonGroup();
            //var group2 = new PersonGroup();

            //personGroups.Add(group1);
            //personGroups.Add(group2);

            // 1) sort the list of persons
            // persons.Sort()
            
            persons.Sort();

            var currentGroup = new PersonGroup();

            

            // 2) repeatedly add next person if they are within distance/ otherwise make new group.
            // foreach person in persons
            foreach (var p in persons)
            {
                // if(current group == empty) add first person
                if (currentGroup.Count == 0)
                {
                    currentGroup.Persons.Add(p); ;
                }
                // else if distance (person, current group[0]) <= distance
                else if (p.Distance(currentGroup[0]) <= distance)
                {
                    // add person
                    currentGroup.Persons.Add(p);
                }
                // else
                else
                {
                    // add the current group to a list of personGroups
                    personGroups.Add(currentGroup);

                    var newCurrentGroup = new PersonGroup();

                    currentGroup = newCurrentGroup;

                    newCurrentGroup.Persons.Add(p);
                }
            }

            

            return personGroups;
        }
    }
}
