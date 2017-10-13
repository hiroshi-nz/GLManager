using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GLManager
{
    class ObjectManager
    {
        public int index { get; set; }
        public List<Object> objects = new List<Object>();

        public ObjectManager()
        {
            index = 0;
        }

        public void AddObject(Object objectToAdd)
        {
            objects.Add(objectToAdd);
        }

        public Object GetCurrentObject()
        {
            return objects[index];
        }

        public Object NextObject()
        {
            if( index + 1 < objects.Count)
            {
                index++;
            }
            else
            {
                index = 0;
            }
            return objects[index];
        }
     
        public void DrawAll()
        {
            foreach(Object anObject in objects)
            {
                anObject.Draw();
            }
        }
    }
}
