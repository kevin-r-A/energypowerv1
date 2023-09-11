using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telerik.Web.UI;
using System.Web.UI;
using System.Collections;

namespace CustomEditors
{
    public class RadFilterDropDownEditor : RadFilterDataFieldEditor
    {
        protected override void CopySettings(RadFilterDataFieldEditor baseEditor)
        {
            base.CopySettings(baseEditor);
            var editor = baseEditor as RadFilterDropDownEditor;
            if (editor != null)
            {
                DataSourceID = editor.DataSourceID;
                DataTextField = editor.DataTextField;
                DataValueField = editor.DataValueField;
            }
        }

        public override System.Collections.ArrayList ExtractValues()
        {
            ArrayList list = new ArrayList();
            list.Add(_combo.SelectedValue);
            return list;
        }

        public override void InitializeEditor(System.Web.UI.Control container)
        {
            _combo = new RadComboBox();
            _combo.ID = "MyCombo";
            _combo.DataTextField = DataTextField;
            _combo.DataValueField = DataValueField;
            _combo.DataSourceID = DataSourceID;

            container.Controls.Add(_combo);
        }


        public override void SetEditorValues(System.Collections.ArrayList values)
        {
            if (values != null && values.Count > 0)
            {
                if (values[0] == null)
                    return;
                _combo.DataBound += (sender, args) =>
                    {
                        var item = _combo.FindItemByValue(values[0].ToString());
                        if (item != null)
                            item.Selected = true;
                    };
            }
        }

        public string DataTextField
        {
            get
            {
                return (string)ViewState["DataTextField"] ?? string.Empty;
            }
            set
            {
                ViewState["DataTextField"] = value;
            }
        }
        public string DataValueField
        {
            get
            {
                return (string)ViewState["DataValueField"] ?? string.Empty;
            }
            set
            {
                ViewState["DataValueField"] = value;
            }
        }
        public string DataSourceID
        {
            get
            {
                return (string)ViewState["DataSourceID"] ?? string.Empty;
            }
            set
            {
                ViewState["DataSourceID"] = value;
            }
        }

        private RadComboBox _combo;
    }
}
