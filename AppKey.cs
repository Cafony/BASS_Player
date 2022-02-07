using System;
using Microsoft.Win32;

namespace player
{
    class AppKey
    {
        private RegistryKey key = null;

        public AppKey(string name)
        {
            key = Registry.CurrentUser.CreateSubKey(name);
        }

        private RegistryKey GetSubKey(ref string name, bool writable)
        {
            // ��������� ������ �� ��� � ����
            string path = "";
            int i = name.LastIndexOf('\\');
            if (i >= 0)
            {
                path = name.Substring(0, i);
                name = name.Substring(i + 1);
            }
            // ���� ���, ���� ������ ��� ��������� - ������ ������ ����
            if (path.Length == 0) return (key);
            // ���� ����, �������� ���� �� ��� ��������� ��� ���������� �������
            return writable ? key.CreateSubKey(path) : key.OpenSubKey(path);
        }

        public void Write(string name, object value)
        {
            GetSubKey(ref name, true).SetValue(name, value);
        }

        public object Read(string name, object defValue)
        {
            RegistryKey nkey = GetSubKey(ref name, false);
            if (nkey != null) return nkey.GetValue(name, defValue);
            return (defValue);
        }

        public bool Exist(string name)
        {
            RegistryKey nkey = GetSubKey(ref name, false);
            return (nkey != null && nkey.GetValue(name) != null);
        }
    }
}
