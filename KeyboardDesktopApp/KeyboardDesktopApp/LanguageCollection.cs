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

        public void SetDefault(string name) {
            foreach (var item in this) {
                item.isDefault = false;
            }
            this.GetLanguageByName(name).isDefault = true;
        }

        public int GetDefaultSID() {
            foreach (var item in this) {
                if (item.isDefault) {
                    return item.serialID;
                }
            }
            throw new System.Exception("No Default!");
        }

        public bool ContainsDefault() {
            foreach (var item in this) {
                if (item.isDefault) {
                    return true;
                }
            }
            return false;
        }
    }
}