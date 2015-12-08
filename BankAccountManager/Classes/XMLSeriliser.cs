using System;
using System.IO;
using System.Xml.Serialization;

namespace BankAccountManager.Classes
{
    //An implementation of the c# xml seriliser that takes generics, allowing this classes reuse in future projects
    //objects to be serilised must have parameterless constructors 

    public class XMLSeriliser<T>
    {
        
        private string path;
        private XmlSerializer serializerObj;
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

        public XmlSerializer SerializerObj
        {
            get
            {
                return serializerObj;
            }
            // no set object, this would upset the seriliser, create a new instance of this class to serilise a different object
        }


        //TODO i used the uk speling of serilise which does not mesh with the constant american spellings found in the libraries, i may have to change this
        public XMLSeriliser(T serialisedClass)
        {
            SerializerObj = new XmlSerializer(serialisedClass.GetType());
            this.serialisedClass = serialisedClass;
            this.path = Environment.CurrentDirectory + @"\" + serialisedClass.GetType().Name + ".xml";
            //The name of the class is based on its type, this ensures a unique default name for saving
            //A new file path can be specified by using the Path setter above
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
