using System;
using System.Text;

public static class ObjectExtensions
{
    public static String SerializeXml(this Object objectContainer, String fileName)
    {
        System.Xml.Serialization.XmlSerializer oXmlSerializer = new System.Xml.Serialization.XmlSerializer(objectContainer.GetType());
        System.IO.StreamWriter oStreamWriter = new System.IO.StreamWriter(fileName, false, Encoding.UTF8);
        oXmlSerializer.Serialize(oStreamWriter, objectContainer);
        oStreamWriter.Close();
        System.IO.StreamReader oStreamReader = new System.IO.StreamReader(fileName, Encoding.UTF8);
        String objectXml = oStreamReader.ReadToEnd();
        oStreamReader.Close();
        return objectXml;
    }

    public static Object DeserializeXml(this Object objectContainer, String fileName)
    {
        if (System.IO.File.Exists(fileName))
        {
            System.Xml.Serialization.XmlSerializer oXmlSerializer = new System.Xml.Serialization.XmlSerializer(objectContainer.GetType());
            System.IO.StreamReader oStreamReader = new System.IO.StreamReader(fileName, Encoding.UTF8);
            try { objectContainer = oXmlSerializer.Deserialize(oStreamReader); }
            catch { objectContainer = null; }
            oStreamReader.Close();
        }
        else { objectContainer.SerializeXml(fileName); }

        return objectContainer;
    }
}