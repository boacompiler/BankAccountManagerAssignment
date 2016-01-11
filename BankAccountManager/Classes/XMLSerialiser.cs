using System;
using System.IO;
using System.Xml.Serialization;

namespace BankAccountManager.Classes
{
    //An implementation of the c# xml seriliser that takes generics, allowing this classes reuse in future projects
    //objects to be serilised must have parameterless constructors 

    public class XMLSerialiser<T>
    {
        
        private string path;
        private XmlSerializer serializerObj;
        private T serialisedClass; //this class must comply to serialiser specifications, but can be any type

        //Getters and Setters
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
        //Constructor
        public XMLSerialiser(T serialisedClass)
        {
            serializerObj = new XmlSerializer(serialisedClass.GetType());
            this.serialisedClass = serialisedClass;
            this.path = Environment.CurrentDirectory + @"\" + serialisedClass.GetType().Name + ".xml";
            //The name of the class is based on its type, this ensures a unique default name for saving
            //A new file path can be specified by using the Path setter above
        }

        //Serialise the data from the class passed in the constructor to the xml file path stored in path
        public void Serialise(T serialiseClass)
        {
            TextWriter WriteFileStream = new StreamWriter(path);           
            SerializerObj.Serialize(WriteFileStream, serialiseClass);
            WriteFileStream.Close();
        }

        //Deserialises the xml file to the passed class, this class must be the same type as the original class
        public T Deserialise(T deserialisedClass)
        {
            try
            {
                FileStream ReadFileStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
                deserialisedClass = (T)SerializerObj.Deserialize(ReadFileStream);
                ReadFileStream.Close();
                return deserialisedClass;
            }
            catch (Exception)
            {
                return deserialisedClass;
            }

        }

    }
}
