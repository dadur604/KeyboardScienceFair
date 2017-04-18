using System.Collections.Generic;

namespace Form1
{
    internal class LanguageCollection : List<Language>
    {
        //public void Add(Language language)
        //{
        //    Add(language);
        //}

        public bool ContainsSerialID(int ID)
        {
            foreach (var item in this)
            {
                if (item.serialID == ID)
                {
                    return true;
                }
            }
            return false;
        }

        public bool ContainsName(string name)
        {
            foreach (var item in this)
            {
                if (item.name == name)
                {
                    return true;
                }
            }
            return false;
        }

        public Language GetLanguageByName(string name)
        {
            foreach (var item in this)
            {
                if (item.name == name)
                {
                    return item;
                }
            }
            throw new System.Exception(string.Format("Does not contain {0}", name));
        }
    }
}