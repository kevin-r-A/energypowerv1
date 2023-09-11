<%@ Control Language="C#" AutoEventWireup="true" CodeFile="wait.ascx.cs" Inherits="Ctrl_wait" %>
    <asp:UpdateProgress ID="upro" runat="server">
        <ProgressTemplate>
            <div id="ModalPopup">
                <div style="position: absolute; left:0px; top:0px; right:0px; bottom:0px; z-index: 10002; background-color: Gray; filter: alpha(opacity=70); opacity: 0.7;"></div>
                    <table style="position: absolute; width: 100%; height: 100%; z-index: 10003; top: 0px; left: 0px;">
                        <tr>
                            <td align="center" valign="middle">
                                <div style="border: 1px solid #333333; color: Black; font-weight: bolder; background-color: White; padding: 15px; width: 200px;">
                                <asp:Image ID="imgw" runat="server" ImageUrl="~/Img/lo2.gif" Height="31px" 
                                        Width="31px" />
                                    <br />
                                    Procesando....
                                </div>
                            </td>
                        </tr>
                    </table>
                 </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    
