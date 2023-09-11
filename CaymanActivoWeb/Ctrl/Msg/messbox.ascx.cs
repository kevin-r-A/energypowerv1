using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Ctrl_Msg_messbox : System.Web.UI.UserControl
{
    string _mensaje;
    string _tip;

    protected void Page_Load(object sender, EventArgs e)
    {
        _mensaje = "";
        _tip = "";
        //img.ImageUrl = "";
    }

    public string Mensaje
    {
        get
        {
            return _mensaje;
        }
        set
        {
            _mensaje = value;
        }
    }
    public string Tipo
    {
        get
        {
            return _tip;
        }
        set
        {
            _tip = value;
        }
    }


    public void showMess()
    {
        lblMsg.Text = _mensaje;

        if (_tip == "S")
        {
            icono.Attributes.Add("class", "glyphicon glyphicon-ok-sign");
            icono.Style.Add("color", "#28a745");
            lbltitu.Text = "Perfecto";
        }
        else if (_tip == "W")
        {
            icono.Attributes.Add("class", "glyphicon glyphicon-alert");
            icono.Style.Add("color", "#ffc107");
            lbltitu.Text = "Advertencia";
        }
        else if (_tip == "E")
        {
            icono.Attributes.Add("class", "glyphicon glyphicon-remove-sign");
            icono.Style.Add("color", "#dc3545");
            lbltitu.Text = "Error";
        }
        else if (_tip == "I")
        {
            icono.Attributes.Add("class", "glyphicon glyphicon-info-sign");
            icono.Style.Add("color", "#17a2b8");
            lbltitu.Text = "Información";
        }
        uptitu.Update();
        upmsg.Update();
        mp.Show();
    }
}