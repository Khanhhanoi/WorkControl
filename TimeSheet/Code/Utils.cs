using System;
using System.Data;
using System.Xml;
using System.Xml.Xsl;
using System.Web;
using System.Text;
using System.Text.RegularExpressions;


namespace TimeSheet
{
    public class Utils
    {
        public static string LinkUrl(int tabID, int mID, string ctl)
        {
            string url = string.Format("/default.aspx?tabID={0}&ctl={1}&mID={2}", tabID.ToString(), ctl, mID.ToString());
            return url;
        }

        public static string LinkUrl(int tabID, int mID, string ctl, int id)
        {
            string url = string.Format("/default.aspx?tabID={0}&ctl={1}&mID={2}&id={3}", tabID.ToString(), ctl, mID.ToString(), id.ToString());
            return url;
        }

        public static void AddNode(XmlDocument doc, XmlElement parent, string name, string text)
        {
            XmlElement node = doc.CreateElement(name);
            node.InnerText = text;
            parent.AppendChild(node);
        }

        public static void InsertAttribute(XmlDocument doc, XmlElement parent, string name, string text)
        {
            XmlAttribute a = doc.CreateAttribute(name);
            a.InnerText = text;
            parent.Attributes.Append(a);
        }

        public static string Transform(string fname_template, XmlDocument doc)
        {
            XslCompiledTransform trans = new XslCompiledTransform();
            trans.Load(System.Web.HttpContext.Current.Server.MapPath(fname_template));
            StringBuilder sb = new StringBuilder();
            XmlWriterSettings setting = new XmlWriterSettings();
            setting.ConformanceLevel = ConformanceLevel.Fragment;
            XmlWriter xw = XmlWriter.Create(sb, setting);
            trans.Transform(new XmlNodeReader(doc), xw);

            return sb.ToString();
        }

        public static DateTime toDate(string dmy)
        {
            DateTime now = DateTime.Now;

            try
            {
                string[] ss = dmy.Split('/');
                if (ss.Length >= 3)
                {
                    int d = Convert.ToInt32(ss[0]);
                    int m = Convert.ToInt32(ss[1]);
                    int y = Convert.ToInt32(ss[2]);

                    return new DateTime(y, m, d, now.Hour, now.Minute, now.Second);
                }
            }
            catch { }

            return new DateTime(1900, 1, 1, 0, 0, 0);
        }

        public static DateTime toDate2(string yyyyDDmm)
        {
            int y = Convert.ToInt32(yyyyDDmm.Substring(0, 4));
            int m = Convert.ToInt32(yyyyDDmm.Substring(4, 2));
            int d = Convert.ToInt32(yyyyDDmm.Substring(6, 2));

            return new DateTime(y, m, d, 0, 0, 0);
        }

        public static DateTime getNgaygio(string ngaythang, string gio, string phut)
        {
            string[] s = ngaythang.Split('/');

            if (s.Length >= 3)
            {
                int ngay = Convert.ToInt32(s[0]);
                int thang = Convert.ToInt32(s[1]);
                int nam = Convert.ToInt32(s[2]);

                return new DateTime(nam, thang, ngay, Convert.ToInt32(gio), Convert.ToInt32(phut), 0);
            }

            return DateTime.Now;
        }

        public static void PagingXML(int page_count, int current_page, string formatUrl, XmlDocument doc)
        {
            int page_per_row = 12;
            int start_index = 0;
            int stop_index = page_count;
            if ((current_page - (page_per_row / 2)) >= start_index)
                start_index = current_page - (page_per_row / 2);
            if ((current_page + (page_per_row / 2)) <= stop_index)
                stop_index = current_page + (page_per_row / 2);

            XmlElement x_pages = doc.CreateElement("pages");
            doc.DocumentElement.AppendChild(x_pages);
            for (int i = start_index; i < stop_index; i++)
            {
                string link = formatUrl.Replace("@@page", Convert.ToString(i + 1));
                XmlElement page = doc.CreateElement("page");
                AddNode(doc, page, "name", Convert.ToString((i + 1)));
                AddNode(doc, page, "link", link);
                if (current_page == i)
                {
                    AddNode(doc, page, "current", "true");
                }
                x_pages.AppendChild(page);
            }

            string first = formatUrl.Replace("@@page", "1");
            string last = formatUrl.Replace("@@page", page_count.ToString());
            string prev = "";
            string next = "";
            if (current_page != 0)
                prev = formatUrl.Replace("@@page", Convert.ToString(current_page));
            if (current_page != (page_count - 1))
                next = formatUrl.Replace("@@page", Convert.ToString(current_page + 2));

            AddNode(doc, x_pages, "first", first);
            AddNode(doc, x_pages, "next", next);
            AddNode(doc, x_pages, "prev", prev);
            AddNode(doc, x_pages, "last", last);
        }

        public static bool NormalChar(char c)
        {
            if ((c <= 'z') && (c >= 'a')) return true;
            if ((c <= 'Z') && (c >= 'A')) return true;
            if ((c <= '9') && (c >= '0')) return true;
            if (c == '_') return true;
            if (c == '-') return true;
            return false;
        }

        public static bool NotUnicodeStr(string str)
        {
            char[] c = str.ToCharArray();
            for (int i = 0; i < c.Length; i++)
                if (!NormalChar(c[i])) return false;
            return true;
        }

        public static bool validEmail(string email)
        {
            string pattern = "^[a-zA-Z][\\w\\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\\w\\.-]*[a-zA-Z0-9]\\.[a-zA-Z][a-zA-Z\\.]*[a-zA-Z]$";
            Regex rx = new Regex(pattern, RegexOptions.IgnoreCase);

            if (!rx.IsMatch(email))
                return false;

            return true;
        }
    }
}