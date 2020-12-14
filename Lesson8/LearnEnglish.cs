using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
namespace Lesson8
{
    // Класс для вопроса    
    [Serializable]
    public class Card
    {
        public string russian;     
        public string english;
        public Card()
        {
        }
        public Card(string russian, string english)
        {
            this.russian = russian;
            this.english = english;
        }
    }
    // Класс для хранения списка слов. А также для сериализации в XML и десериализации из XML
    class LearnEnglish
    {
        public bool isSaved;
        public string fileName;
        List<Card> list;
        public string FileName
        {
            set { fileName = value; }
        }
        public LearnEnglish(string fileName)
        {
            this.fileName = fileName;
            list = new List<Card>();
            isSaved = true; 
        }
        public void Add(string russian, string english)
        {
            list.Add(new Card(russian, english));
        }
        public void Remove(int index)
        {
            if (list != null && index < list.Count && index >= 0) list.RemoveAt(index);
        }
        // Индексатор - свойство для доступа к закрытому объекту
        public Card this[int index]
        {
            get { return list[index]; }
        }
        public void Save()
        {
            XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Card>));
            Stream fStream = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            xmlFormat.Serialize(fStream, list);
            fStream.Close();
        }
        public void Load()
        {
            XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Card>));
            Stream fStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            list = (List<Card>)xmlFormat.Deserialize(fStream);
            fStream.Close();
        }
        public int Count
        {
            get { return list.Count; }
        }
    }
}
