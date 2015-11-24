using System;

using System.IO;
using System.Xml.Serialization;

namespace BankAccountManager.Classes
{
    class XMLSeriliser<T>
    {

        private string path;
        private XmlSerializer SerializerObj;
        private T serialisedClass;

        public string Path
        {
            get
            {
                return path;
            }

            set
            {
                path = value;
            }
        }

        public XmlSerializer SerializerObj1
        {
            get
            {
                return SerializerObj;
            }
            // no set, this would upset the seriliser, just create a new instance of this class to serilise a different object
        }


        //TODO i used the uk speling of serilise which does not mesh with the constant american spellings found in the libraries, i may have to change this
        public XMLSeriliser(T serialisedClass)
        {
            //SerializerObj = new XmlSerializer(typeof(T));
            SerializerObj = new XmlSerializer(serialisedClass.GetType());
            this.serialisedClass = serialisedClass;
            this.path = Environment.CurrentDirectory + @"\" + serialisedClass.GetType().Name + ".xml";
            //this.path = Environment.CurrentDirectory + @"\test.xml";
        }

        public void Serialise()
        {
            TextWriter WriteFileStream = new StreamWriter(path);
            SerializerObj.Serialize(WriteFileStream, serialisedClass);
            WriteFileStream.Close();
        }

        public T Deserialise(T serialisedClass)
        {
            FileStream ReadFileStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
            serialisedClass = (T)SerializerObj.Deserialize(ReadFileStream);
            ReadFileStream.Close();
            return serialisedClass;
        }

    }
}
