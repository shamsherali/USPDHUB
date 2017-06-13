using System;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace CSSFriendly
{
    public class MenuAdapter : System.Web.UI.WebControls.Adapters.MenuAdapter
    {
        public MenuAdapter()
        {
            //
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            RegisterScripts();
        }

        private void RegisterScripts()
        {
            string abc = HttpContext.Current.Request.ServerVariables["URL"].ToString();
            Utility.RegisterScripts(Page);
            Page.ClientScript.RegisterClientScriptInclude(GetType(), GetType().ToString(), Page.ResolveUrl("~/Scripts/MenuAdapter.js"));

        }

        protected override void RenderBeginTag(HtmlTextWriter writer)
        {
            if ((Control != null) && (Control.Attributes["CssSelectorClass"] != null) && (Control.Attributes["CssSelectorClass"].Length > 0))
            {
                writer.WriteLine();
                writer.WriteBeginTag("div");
                writer.WriteAttribute("class", Control.Attributes["CssSelectorClass"]);
                writer.Write(HtmlTextWriter.TagRightChar);
                writer.Indent++;
            }

            writer.WriteLine();
            writer.WriteBeginTag("div");
            writer.WriteAttribute("class", "AspNet-Menu-" + Control.Orientation.ToString());
            writer.Write(HtmlTextWriter.TagRightChar);
        }

        protected override void RenderEndTag(HtmlTextWriter writer)
        {
            writer.WriteEndTag("div");

            if ((Control != null) && (Control.Attributes["CssSelectorClass"] != null) && (Control.Attributes["CssSelectorClass"].Length > 0))
            {
                writer.Indent--;
                writer.WriteLine();
                writer.WriteEndTag("div");
            }

            writer.WriteLine();
        }

        protected override void RenderContents(HtmlTextWriter writer)
        {
            writer.Indent++;
            BuildItems(Control.Items, true, writer);
            writer.Indent--;
            writer.WriteLine();
        }

        private void BuildItems(MenuItemCollection items, bool isRoot, HtmlTextWriter writer)
        {

            if (items.Count > 0)
            {
                writer.WriteLine();
                writer.WriteBeginTag("div>");
                writer.WriteBeginTag("ul");

                if (isRoot)
                {
                    writer.WriteAttribute("class", "AspNet-Menu");
                }
                writer.Write(HtmlTextWriter.TagRightChar);
                writer.Indent++;

                foreach (MenuItem item in items)
                {
                    BuildItem(item, writer, isRoot);
                }

                writer.Indent--;
                writer.WriteLine();

                writer.WriteEndTag("ul");
                writer.WriteEndTag("div");

            }
        }

        private void BuildItem(MenuItem item, HtmlTextWriter writer, bool isRoot)
        {
            Menu menu = Control as Menu;
            if ((menu != null) && (item != null) && (writer != null))
            {
                writer.WriteLine();
                if (isRoot == true)
                {
                    writer.WriteBeginTag("li");
                    writer.WriteAttribute("class", "AspNet-Menu-WithChildren");
                    writer.Write(HtmlTextWriter.TagRightChar);
                    writer.Indent++;
                }
                else
                {
                    writer.WriteBeginTag("li");
                    if (item.NavigateUrl.Contains("div"))
                    {
                        if ((Control != null) && (Control.Attributes["CssSelectorClass"] != null) && (Control.Attributes["CssSelectorClass"].Length > 0))
                        {
                            if (Control.Attributes["CssSelectorClass"].ToString() == "PrettyMenu")
                            {
                                writer.WriteAttribute("class", "AspNet-Menu-WithChildren1D");
                            }
                            else
                            {
                                writer.WriteAttribute("class", "AspNet-Menu-WithChildren1");
                            }
                        }

                    }
                    else
                    {
                        if ((Control != null) && (Control.Attributes["CssSelectorClass"] != null) && (Control.Attributes["CssSelectorClass"].Length > 0))
                        {
                            if (Control.Attributes["CssSelectorClass"].ToString() == "PrettyMenu")
                            {
                                writer.WriteAttribute("class", item.ChildItems.Count > 0 ? "AspNet-Menu-WithChildren1D" : "AspNet-Menu-LeafD");
                            }
                            else
                            {
                                writer.WriteAttribute("class", item.ChildItems.Count > 0 ? "AspNet-Menu-WithChildren1" : "AspNet-Menu-Leaf");
                            }
                        }


                    }
                    writer.Write(HtmlTextWriter.TagRightChar);
                    writer.Indent++;
                }
                writer.WriteLine();
                if (item.ImageUrl.Length > 0)
                {
                    writer.WriteBeginTag("img");
                    writer.WriteAttribute("src", Page.ResolveUrl(item.ImageUrl));
                    writer.WriteAttribute("alt", item.ToolTip.Length > 0 ? item.ToolTip : (menu.ToolTip.Length > 0 ? menu.ToolTip : item.Text));
                    writer.Write(HtmlTextWriter.SelfClosingTagEnd);
                }
                if (item.NavigateUrl.Length > 0)
                {
                    writer.WriteBeginTag("a");
                    writer.WriteAttribute("href", Page.ResolveUrl(item.NavigateUrl));
                    if (isRoot == true)
                    {
                        writer.WriteAttribute("class", "dbli");
                    }
                    else
                    {
                        if (item.NavigateUrl.Contains("Tracking Reports"))
                        {
                            writer.WriteAttribute("class", "sublink");
                        }
                        else if (item.NavigateUrl.Contains("div"))
                        {
                            writer.WriteAttribute("class", "sublink");
                        }

                        else
                        {
                            if (Control.Attributes["CssSelectorClass"].ToString() == "PrettyMenu")
                            {
                                writer.WriteAttribute("class", "AspNet-Menu-Test1D");
                            }
                            else
                            {
                                writer.WriteAttribute("class", "AspNet-Menu-Test1");
                            }
                            //writer.WriteAttribute("class", "AspNet-Menu-Test1");
                        }
                    }
                    if (item.Target.Length > 0)
                    {
                        writer.WriteAttribute("target", item.Target);
                    }
                    if (item.ToolTip.Length > 0)
                    {
                        writer.WriteAttribute("title", item.ToolTip);
                    }
                    else if (menu.ToolTip.Length > 0)
                    {
                        writer.WriteAttribute("title", menu.ToolTip);
                    }
                    writer.Write(HtmlTextWriter.TagRightChar);
                    writer.Indent++;
                    writer.WriteLine();
                }
                else
                {
                    writer.WriteBeginTag("span");
                    writer.WriteAttribute("class", "AspNet-Menu-Test1");
                    writer.Write(HtmlTextWriter.TagRightChar);
                    writer.Indent++;
                    writer.WriteLine();
                }
                writer.Write(item.Text);
                if (item.NavigateUrl.Length > 0)
                {
                    writer.Indent--;
                    writer.WriteLine();
                    writer.WriteEndTag("a");
                }
                else
                {
                    writer.Indent--;
                    writer.WriteLine();
                    writer.WriteEndTag("span");
                }

                if ((item.ChildItems != null) && (item.ChildItems.Count > 0))
                {
                    BuildItems(item.ChildItems, false, writer);
                }
                writer.Indent--;
                writer.WriteLine();
                writer.WriteEndTag("li");
            }
        }
    }
}
