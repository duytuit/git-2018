using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace HTQuanLyFilm.Code
{
    public class LoginRedirectByRoleSection : ConfigurationSection
    {
        [ConfigurationProperty("roleRedirects")]
        public RoleRedirectCollection RoleRedirects
        {
            get
            {
                return (RoleRedirectCollection)this["roleRedirects"];
            }
            set
            {
                this["roleRedirects"] = value;
            }
        }
    }
    public class RoleRedirectCollection : ConfigurationElementCollection
    {
        public RoleRedirect this[int index]
        {
            get
            {
                return (RoleRedirect)BaseGet(index);
            }
        }

        public RoleRedirect this[object key]
        {
            get
            {
                return (RoleRedirect)BaseGet(key);
            }
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new RoleRedirect();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((RoleRedirect)element).Role;
        }
    }

    public class RoleRedirect : ConfigurationElement
    {
        [ConfigurationProperty("role", IsRequired = true)]
        public string Role
        {
            get
            {
                return (string)this["role"];
            }
            set
            {
                this["role"] = value;
            }
        }

        [ConfigurationProperty("url", IsRequired = true)]
        public string Url
        {
            get
            {
                return (string)this["url"];
            }
            set
            {
                this["url"] = value;
            }
        }
    }
}