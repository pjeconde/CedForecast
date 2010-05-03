<%@ Page Language="C#" MasterPageFile="~/Forecast/Forecast.Master" AutoEventWireup="true" CodeBehind="Proyectado.aspx.cs" Inherits="CedForecastWeb.Forecast.Proyectado" StylesheetTheme="Cedeira" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>

<%@ Register Assembly="CedeiraUIWebForms" Namespace="CedeiraUIWebForms" TagPrefix="cc1" %>

<%@ Register Src="~/DatePickerWebUserControl.ascx" TagName="DatePickerWebUserControl"
	TagPrefix="uc1" %>

<asp:content id="ForecastContent" runat="Server" contentplaceholderid="ForecastContentPlaceHolder">
    <table border="0" cellpadding="0" cellspacing="0" class="TextoComun" style="width: 890px; text-align: left; background-color: white">
        <tr>
            <td style="height: 10px;" valign="top">
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
            </td>
        </tr>
        <tr>
            <td style="padding-left: 10px; padding-right: 10px; width: 100%" valign="top">
                <table border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td valign="top">
                            <!-- @@@ TITULO DE LA PAGINA @@@-->
                            <table border="0" cellpadding="0" cellspacing="0" id="TablaTit" onclick="">
        						<tr>
                                    <td style="width: 20px; vertical-align:top;">
                                        <table border="0" cellpadding="0" cellspacing="0" id="Table3">
        						            <tr>
                                                <td style="height: 3px">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Image ID="Image2" runat="server" AlternateText="o" ImageUrl="~/Imagenes/button_link.gif" />
                                                </td>
                                            </tr>
                                           
                                        </table>   
                                    </td>
                                    <td style="width: 870px">
                                        <asp:Label ID="TituloLabel" SkinID="TituloPagina" runat="server" Text="Forecast Proyectado"></asp:Label>&nbsp;&nbsp;
                                        <asp:Label ID="MsgLabel" runat="server" Width="697px"></asp:Label>
                                        <hr />
                                    </td>
                               </tr>
                           </table>
                           <table border="0" cellpadding="0" cellspacing="0" id="TablaDet">    
                                <tr>
                                    <td colspan="4" style="">
                                        <asp:Panel ID="CabeceraFijaPanel" runat="server" Enabled="false">
                                            <table border="0" cellpadding="0" cellspacing="0" id="CabeceraFijaTable">
                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td align="right" style="height: 10px" valign="middle">
                                                        <asp:Label ID="FechaLabel" runat="server" SkinID="TituloMediano" Text="Período:"></asp:Label>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td align="left" style="width: 392px;" valign="top">
                                                        <asp:TextBox ID="PeriodoTextBox" runat="server" Width="75px"></asp:TextBox>&nbsp;&nbsp;
                                                        <asp:Label ID="FechaVtoConfimacionCargaLabel" runat="server" SkinID="TituloMediano" Font-Bold="False"  ></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 10px;">
                                                    </td>
                                                    <td align="left" style="width: 100px; height: 5px" valign="middle">
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td align="left" style="width: 392px;" valign="top">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td align="right" style="height: 10px" valign="middle">
                                                        <asp:Label ID="DivisionLabel" runat="server" SkinID="TituloMediano" Text="División: "></asp:Label>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td align="left" style="width: 392px;" valign="top"><asp:DropDownList ID="DivisionDropDownList" runat="server" TabIndex="9" Width="388px" OnSelectedIndexChanged="DivisionDropDownList_SelectedIndexChanged">
                                                    </asp:DropDownList></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td align="left" style="height: 5px" valign="middle">
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td align="left" style="width: 392px;" valign="top">
                                                        &nbsp;</td>
                                                </tr>
                                            </table>
                                         </asp:Panel>
                                         <asp:Panel ID="SeleccionPanel" runat="server" Enabled="true">
                                            <table border="0" cellpadding="0" cellspacing="0" id="SeleccionTable">
                                                <tr>
                                                    <td style="width: 10px;">
                                                    </td>
                                                    <td align="right" style="width: 100px; height: 10px;" valign="middle">
                                                        <asp:Label ID="ClienteLabel" runat="server" SkinID="TituloMediano" Text="Cliente:"></asp:Label>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td align="left" style="width: 392px;" valign="top">
                                                        <asp:DropDownList ID="ClienteDropDownList" runat="server" TabIndex="10" Width="388px" OnSelectedIndexChanged="ClienteDropDownList_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4" style="height: 10px;">
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4" style="" valign="middle">
                                        <asp:Button ID="LeerButton" runat="server" OnClick="LeerButton_Click" Text="Leer" Width="870px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 10px;">
                                    </td>
                                </tr>
                            </table>
                            <table border="0" cellpadding="0" cellspacing="0" style="width:870px" id="TablaGrilla" onclick="">
						        <tr>
                                    <td colspan="3">
                                        <asp:UpdatePanel ID="detalleUpdatePanel" runat="server">
                                            <ContentTemplate>
										        <asp:Panel ID="detallePanel" runat="server" BorderStyle="Ridge" Height="200px" ScrollBars="Auto" Width="865px" Wrap="true">
											        <asp:GridView ID="detalleGridView" runat="server" AutoGenerateColumns="False" BorderColor="Gray"
												        BorderStyle="Solid" BorderWidth="1px" EditRowStyle-ForeColor="#071F70" EmptyDataRowStyle-ForeColor="#071F70" Font-Bold="False" ForeColor="#071F70"
												        HeaderStyle-ForeColor="#A52A2A" OnRowCancelingEdit="detalleGridView_RowCancelingEdit"
												        OnRowCommand="detalleGridView_RowCommand" OnRowDeleted="detalleGridView_RowDeleted"
												        OnRowDeleting="detalleGridView_RowDeleting" OnRowEditing="detalleGridView_RowEditing"
												        OnRowUpdated="detalleGridView_RowUpdated" OnRowUpdating="detalleGridView_RowUpdating"
												        PagerStyle-ForeColor="#071F70" RowStyle-ForeColor="#071F70" SelectedRowStyle-ForeColor="#071F70"
												        ShowFooter="True" ToolTip="Recuerde que al ingresar importes con decimales el separador a utilizar es el punto" Width="100%" OnSelectedIndexChanged="detalleGridView_SelectedIndexChanged">
												        <Columns>
													        <asp:TemplateField HeaderText="Descripci&#243;n del Art&#237;culo">
														        <ItemTemplate>
															        <asp:Label ID="lblIdArticulo" runat="server" Text='<%# Eval("DescrArticulo") %>'
																        Width="230px"></asp:Label>
														        </ItemTemplate>
														        <EditItemTemplate>
															        <asp:DropDownList ID="ddlIdArticuloEdit" runat="server" Width="230px">
															        </asp:DropDownList>
														        </EditItemTemplate>
														        <FooterTemplate>
															        <asp:DropDownList ID="ddlIdArticulo" runat="server" Width="230px">
															        </asp:DropDownList>
														        </FooterTemplate>
														        <ItemStyle HorizontalAlign="Left" />
                                                                <HeaderStyle Font-Bold="False" />
													        </asp:TemplateField>
													        <asp:TemplateField HeaderText="Total" HeaderStyle-HorizontalAlign="Right">
														        <ItemTemplate>
															        <asp:Label ID="lblTotal" runat="server" Text='<%# Eval("CantidadTotal") %>' Width="100px" SkinID="TextoMedianoEdit"></asp:Label>
														        </ItemTemplate>
														        <ItemStyle HorizontalAlign="Right" />
                                                                <HeaderStyle Font-Bold="False" Width="100px" />
													        </asp:TemplateField>
													        <asp:TemplateField HeaderText="Cantidad1" HeaderStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right">
														        <ItemTemplate>
															        <asp:Label ID="lblCantidad1" runat="server" Text='<%# Eval("Cantidad1") %>' Width="80px"></asp:Label>
														        </ItemTemplate>
														        <EditItemTemplate>
															        <asp:TextBox ID="txtCantidad1Edit" runat="server" Text='<%# Eval("Cantidad1") %>' Width="70px" SkinID="TextoBoxChico"></asp:TextBox><asp:RegularExpressionValidator
																        ID="txtcantidad1EditRegularExpressionValidator" runat="server" ControlToValidate="txtCantidad1Edit"
																        ErrorMessage="Cantidad del artículo en edición mal formateado" SetFocusOnError="true"
																        ValidationExpression="[0-9]+(\.[0-9]+)?" ValidationGroup="DetalleEditItem">*</asp:RegularExpressionValidator>
														        </EditItemTemplate>
														        <FooterTemplate>
															        <asp:TextBox ID="txtCantidad1" runat="server" Text='0' Width="70px" SkinID="TextoBoxChico"></asp:TextBox><asp:RegularExpressionValidator
																        ID="txtcantidad1FooterRegularExpressionValidator" runat="server" ControlToValidate="txtCantidad1"
																        ErrorMessage="Cantidad del artículo a agregar mal formateado" SetFocusOnError="true"
																        ValidationExpression="[0-9]+(\.[0-9]+)?" ValidationGroup="DetalleFooter">*</asp:RegularExpressionValidator>
														        </FooterTemplate>
														        <ItemStyle HorizontalAlign="Right" />
                                                                <HeaderStyle Font-Bold="False" Width="80px" />
													        </asp:TemplateField>
													        <asp:TemplateField HeaderText="Cantidad2" HeaderStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right">
														        <ItemTemplate>
															        <asp:Label ID="lblCantidad2" runat="server" Text='<%# Eval("Cantidad2") %>' Width="80px"></asp:Label>
														        </ItemTemplate>
														        <EditItemTemplate>
															        <asp:TextBox ID="txtCantidad2Edit" runat="server" Text='<%# Eval("Cantidad2") %>' Width="70px" SkinID="TextoBoxChico"></asp:TextBox><asp:RegularExpressionValidator
																        ID="txtcantidad2EditRegularExpressionValidator" runat="server" ControlToValidate="txtCantidad2Edit"
																        ErrorMessage="Cantidad del artículo en edición mal formateado" SetFocusOnError="true"
																        ValidationExpression="[0-9]+(\.[0-9]+)?" ValidationGroup="DetalleEditItem">*</asp:RegularExpressionValidator>
														        </EditItemTemplate>
														        <FooterTemplate>
															        <asp:TextBox ID="txtCantidad2" runat="server" Text='0' Width="70px" SkinID="TextoBoxChico"></asp:TextBox><asp:RegularExpressionValidator
																        ID="txtcantidad2FooterRegularExpressionValidator" runat="server" ControlToValidate="txtCantidad2"
																        ErrorMessage="Cantidad del artículo a agregar mal formateado" SetFocusOnError="true"
																        ValidationExpression="[0-9]+(\.[0-9]+)?" ValidationGroup="DetalleFooter">*</asp:RegularExpressionValidator>
														        </FooterTemplate>
														        <ItemStyle HorizontalAlign="Right" />
                                                                <HeaderStyle Font-Bold="False" Width="80px" />
													        </asp:TemplateField>
													        <asp:TemplateField HeaderText="Cantidad3" HeaderStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right">
														        <ItemTemplate>
															        <asp:Label ID="lblCantidad3" runat="server" Text='<%# Eval("Cantidad3") %>' Width="80px"></asp:Label>
														        </ItemTemplate>
														        <EditItemTemplate>
															        <asp:TextBox ID="txtCantidad3Edit" runat="server" Text='<%# Eval("Cantidad3") %>' Width="70px" SkinID="TextoBoxChico"></asp:TextBox><asp:RegularExpressionValidator
																        ID="txtcantidad3EditRegularExpressionValidator" runat="server" ControlToValidate="txtCantidad3Edit"
																        ErrorMessage="Cantidad del artículo en edición mal formateado" SetFocusOnError="true"
																        ValidationExpression="[0-9]+(\.[0-9]+)?" ValidationGroup="DetalleEditItem">*</asp:RegularExpressionValidator>
														        </EditItemTemplate>
														        <FooterTemplate>
															        <asp:TextBox ID="txtCantidad3" runat="server" Text='0' Width="70px" SkinID="TextoBoxChico"></asp:TextBox><asp:RegularExpressionValidator
																        ID="txtcantidad3FooterRegularExpressionValidator" runat="server" ControlToValidate="txtCantidad3"
																        ErrorMessage="Cantidad del artículo a agregar mal formateado" SetFocusOnError="true"
																        ValidationExpression="[0-9]+(\.[0-9]+)?" ValidationGroup="DetalleFooter">*</asp:RegularExpressionValidator>
														        </FooterTemplate>
														        <ItemStyle HorizontalAlign="Right" />
                                                                <HeaderStyle Font-Bold="False" Width="80px" />
													        </asp:TemplateField>
													        <asp:TemplateField HeaderText="Cantidad4" HeaderStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right">
														        <ItemTemplate>
															        <asp:Label ID="lblCantidad4" runat="server" Text='<%# Eval("Cantidad4") %>' Width="80px"></asp:Label>
														        </ItemTemplate>
														        <EditItemTemplate>
															        <asp:TextBox ID="txtCantidad4Edit" runat="server" Text='<%# Eval("Cantidad4") %>' Width="70px" SkinID="TextoBoxChico"></asp:TextBox><asp:RegularExpressionValidator
																        ID="txtcantidad4EditRegularExpressionValidator" runat="server" ControlToValidate="txtCantidad4Edit"
																        ErrorMessage="Cantidad del artículo en edición mal formateado" SetFocusOnError="true"
																        ValidationExpression="[0-9]+(\.[0-9]+)?" ValidationGroup="DetalleEditItem">*</asp:RegularExpressionValidator>
														        </EditItemTemplate>
														        <FooterTemplate>
															        <asp:TextBox ID="txtCantidad4" runat="server" Text='0' Width="70px" SkinID="TextoBoxChico"></asp:TextBox><asp:RegularExpressionValidator
																        ID="txtcantidad4FooterRegularExpressionValidator" runat="server" ControlToValidate="txtCantidad4"
																        ErrorMessage="Cantidad del artículo a agregar mal formateado" SetFocusOnError="true"
																        ValidationExpression="[0-9]+(\.[0-9]+)?" ValidationGroup="DetalleFooter">*</asp:RegularExpressionValidator>
														        </FooterTemplate>
														        <ItemStyle HorizontalAlign="Right" />
                                                                <HeaderStyle Font-Bold="False" Width="80px" />
													        </asp:TemplateField>
													        <asp:TemplateField HeaderText="Cantidad5" HeaderStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right">
														        <ItemTemplate>
															        <asp:Label ID="lblCantidad5" runat="server" Text='<%# Eval("Cantidad5") %>' Width="80px"></asp:Label>
														        </ItemTemplate>
														        <EditItemTemplate>
															        <asp:TextBox ID="txtCantidad5Edit" runat="server" Text='<%# Eval("Cantidad5") %>' Width="70px" SkinID="TextoBoxChico"></asp:TextBox><asp:RegularExpressionValidator
																        ID="txtcantidad5EditRegularExpressionValidator" runat="server" ControlToValidate="txtCantidad5Edit"
																        ErrorMessage="Cantidad del artículo en edición mal formateado" SetFocusOnError="true"
																        ValidationExpression="[0-9]+(\.[0-9]+)?" ValidationGroup="DetalleEditItem">*</asp:RegularExpressionValidator>
														        </EditItemTemplate>
														        <FooterTemplate>
															        <asp:TextBox ID="txtCantidad5" runat="server" Text='0' Width="70px" SkinID="TextoBoxChico"></asp:TextBox><asp:RegularExpressionValidator
																        ID="txtcantidad5FooterRegularExpressionValidator" runat="server" ControlToValidate="txtCantidad5"
																        ErrorMessage="Cantidad del artículo a agregar mal formateado" SetFocusOnError="true"
																        ValidationExpression="[0-9]+(\.[0-9]+)?" ValidationGroup="DetalleFooter">*</asp:RegularExpressionValidator>
														        </FooterTemplate>
														        <ItemStyle HorizontalAlign="Right" />
                                                                <HeaderStyle Font-Bold="False" Width="80px" />
													        </asp:TemplateField>
													        <asp:TemplateField HeaderText="Cantidad6" HeaderStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right">
														        <ItemTemplate>
															        <asp:Label ID="lblCantidad6" runat="server" Text='<%# Eval("Cantidad6") %>' Width="80px"></asp:Label>
														        </ItemTemplate>
														        <EditItemTemplate>
															        <asp:TextBox ID="txtCantidad6Edit" runat="server" Text='<%# Eval("Cantidad6") %>' Width="70px" SkinID="TextoBoxChico"></asp:TextBox><asp:RegularExpressionValidator
																        ID="cantidad6EditRegularExpressionValidator" runat="server" ControlToValidate="txtCantidad6Edit"
																        ErrorMessage="Cantidad del artículo en edición mal formateado" SetFocusOnError="true"
																        ValidationExpression="[0-9]+(\.[0-9]+)?" ValidationGroup="DetalleEditItem">*</asp:RegularExpressionValidator>
														        </EditItemTemplate>
														        <FooterTemplate>
															        <asp:TextBox ID="txtCantidad6" runat="server" Text='0' Width="70px" SkinID="TextoBoxChico"></asp:TextBox><asp:RegularExpressionValidator
																        ID="txtcantidad6FooterRegularExpressionValidator" runat="server" ControlToValidate="txtCantidad6"
																        ErrorMessage="Cantidad del artículo a agregar mal formateado" SetFocusOnError="true"
																        ValidationExpression="[0-9]+(\.[0-9]+)?" ValidationGroup="DetalleFooter">*</asp:RegularExpressionValidator>
														        </FooterTemplate>
														        <ItemStyle HorizontalAlign="Right" />
                                                                <HeaderStyle Font-Bold="False" Width="80px" />
													        </asp:TemplateField> 
													        <asp:TemplateField HeaderText="Cantidad7" HeaderStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right">
														        <ItemTemplate>
															        <asp:Label ID="lblCantidad7" runat="server" Text='<%# Eval("Cantidad7") %>' Width="80px"></asp:Label>
														        </ItemTemplate>
														        <EditItemTemplate>
															        <asp:TextBox ID="txtCantidad7Edit" runat="server" Text='<%# Eval("Cantidad7") %>' Width="70px" SkinID="TextoBoxChico"></asp:TextBox><asp:RegularExpressionValidator
																        ID="cantidad7EditRegularExpressionValidator" runat="server" ControlToValidate="txtCantidad7Edit"
																        ErrorMessage="Cantidad del artículo en edición mal formateado" SetFocusOnError="true"
																        ValidationExpression="[0-9]+(\.[0-9]+)?" ValidationGroup="DetalleEditItem">*</asp:RegularExpressionValidator>
														        </EditItemTemplate>
														        <FooterTemplate>
															        <asp:TextBox ID="txtCantidad7" runat="server" Text='0' Width="70px" SkinID="TextoBoxChico"></asp:TextBox><asp:RegularExpressionValidator
																        ID="txtcantidad7FooterRegularExpressionValidator" runat="server" ControlToValidate="txtCantidad7"
																        ErrorMessage="Cantidad del artículo a agregar mal formateado" SetFocusOnError="true"
																        ValidationExpression="[0-9]+(\.[0-9]+)?" ValidationGroup="DetalleFooter">*</asp:RegularExpressionValidator>
														        </FooterTemplate>
														        <ItemStyle HorizontalAlign="Right" />
                                                                <HeaderStyle Font-Bold="False" Width="80px" />
													        </asp:TemplateField> 
													        <asp:TemplateField HeaderText="Cantidad8" HeaderStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right">
														        <ItemTemplate>
															        <asp:Label ID="lblCantidad8" runat="server" Text='<%# Eval("Cantidad8") %>' Width="80px"></asp:Label>
														        </ItemTemplate>
														        <EditItemTemplate>
															        <asp:TextBox ID="txtCantidad8Edit" runat="server" Text='<%# Eval("Cantidad8") %>' Width="70px" SkinID="TextoBoxChico"></asp:TextBox><asp:RegularExpressionValidator
																        ID="cantidad8EditRegularExpressionValidator" runat="server" ControlToValidate="txtCantidad8Edit"
																        ErrorMessage="Cantidad del artículo en edición mal formateado" SetFocusOnError="true"
																        ValidationExpression="[0-9]+(\.[0-9]+)?" ValidationGroup="DetalleEditItem">*</asp:RegularExpressionValidator>
														        </EditItemTemplate>
														        <FooterTemplate>
															        <asp:TextBox ID="txtCantidad8" runat="server" Text='0' Width="70px" SkinID="TextoBoxChico"></asp:TextBox><asp:RegularExpressionValidator
																        ID="txtcantidad8FooterRegularExpressionValidator" runat="server" ControlToValidate="txtCantidad8"
																        ErrorMessage="Cantidad del artículo a agregar mal formateado" SetFocusOnError="true"
																        ValidationExpression="[0-9]+(\.[0-9]+)?" ValidationGroup="DetalleFooter">*</asp:RegularExpressionValidator>
														        </FooterTemplate>
														        <ItemStyle HorizontalAlign="Right" />
                                                                <HeaderStyle Font-Bold="False" Width="80px" />
													        </asp:TemplateField> 	
													        <asp:TemplateField HeaderText="Cantidad9" HeaderStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right">
														        <ItemTemplate>
															        <asp:Label ID="lblCantidad9" runat="server" Text='<%# Eval("Cantidad9") %>' Width="80px"></asp:Label>
														        </ItemTemplate>
														        <EditItemTemplate>
															        <asp:TextBox ID="txtCantidad9Edit" runat="server" Text='<%# Eval("Cantidad9") %>' Width="70px" SkinID="TextoBoxChico"></asp:TextBox><asp:RegularExpressionValidator
																        ID="cantidad9EditRegularExpressionValidator" runat="server" ControlToValidate="txtCantidad9Edit"
																        ErrorMessage="Cantidad del artículo en edición mal formateado" SetFocusOnError="true"
																        ValidationExpression="[0-9]+(\.[0-9]+)?" ValidationGroup="DetalleEditItem">*</asp:RegularExpressionValidator>
														        </EditItemTemplate>
														        <FooterTemplate>
															        <asp:TextBox ID="txtCantidad9" runat="server" Text='0' Width="70px" SkinID="TextoBoxChico"></asp:TextBox><asp:RegularExpressionValidator
																        ID="txtcantidad9FooterRegularExpressionValidator" runat="server" ControlToValidate="txtCantidad9"
																        ErrorMessage="Cantidad del artículo a agregar mal formateado" SetFocusOnError="true"
																        ValidationExpression="[0-9]+(\.[0-9]+)?" ValidationGroup="DetalleFooter">*</asp:RegularExpressionValidator>
														        </FooterTemplate>
														        <ItemStyle HorizontalAlign="Right" />
                                                                <HeaderStyle Font-Bold="False" Width="80px" />
													        </asp:TemplateField> 	
													        <asp:TemplateField HeaderText="Cantidad10" HeaderStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right">
														        <ItemTemplate>
															        <asp:Label ID="lblCantidad10" runat="server" Text='<%# Eval("Cantidad10") %>' Width="80px"></asp:Label>
														        </ItemTemplate>
														        <EditItemTemplate>
															        <asp:TextBox ID="txtCantidad10Edit" runat="server" Text='<%# Eval("Cantidad10") %>' Width="70px" SkinID="TextoBoxChico"></asp:TextBox><asp:RegularExpressionValidator
																        ID="cantidad10EditRegularExpressionValidator" runat="server" ControlToValidate="txtCantidad10Edit"
																        ErrorMessage="Cantidad del artículo en edición mal formateado" SetFocusOnError="true"
																        ValidationExpression="[0-9]+(\.[0-9]+)?" ValidationGroup="DetalleEditItem">*</asp:RegularExpressionValidator>
														        </EditItemTemplate>
														        <FooterTemplate>
															        <asp:TextBox ID="txtCantidad10" runat="server" Text='0' Width="70px" SkinID="TextoBoxChico"></asp:TextBox><asp:RegularExpressionValidator
																        ID="txtcantidad10FooterRegularExpressionValidator" runat="server" ControlToValidate="txtCantidad10"
																        ErrorMessage="Cantidad del artículo a agregar mal formateado" SetFocusOnError="true"
																        ValidationExpression="[0-9]+(\.[0-9]+)?" ValidationGroup="DetalleFooter">*</asp:RegularExpressionValidator>
														        </FooterTemplate>
														        <ItemStyle HorizontalAlign="Right" />
                                                                <HeaderStyle Font-Bold="False" Width="80px" />
													        </asp:TemplateField> 
													        <asp:TemplateField HeaderText="Cantidad11" HeaderStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right">
														        <ItemTemplate>
															        <asp:Label ID="lblCantidad11" runat="server" Text='<%# Eval("Cantidad11") %>' Width="80px"></asp:Label>
														        </ItemTemplate>
														        <EditItemTemplate>
															        <asp:TextBox ID="txtCantidad11Edit" runat="server" Text='<%# Eval("Cantidad11") %>' Width="70px" SkinID="TextoBoxChico"></asp:TextBox><asp:RegularExpressionValidator
																        ID="cantidad11EditRegularExpressionValidator" runat="server" ControlToValidate="txtCantidad11Edit"
																        ErrorMessage="Cantidad del artículo en edición mal formateado" SetFocusOnError="true"
																        ValidationExpression="[0-9]+(\.[0-9]+)?" ValidationGroup="DetalleEditItem">*</asp:RegularExpressionValidator>
														        </EditItemTemplate>
														        <FooterTemplate>
															        <asp:TextBox ID="txtCantidad11" runat="server" Text='0' Width="70px" SkinID="TextoBoxChico"></asp:TextBox><asp:RegularExpressionValidator
																        ID="txtcantidad11FooterRegularExpressionValidator" runat="server" ControlToValidate="txtCantidad11"
																        ErrorMessage="Cantidad del artículo a agregar mal formateado" SetFocusOnError="true"
																        ValidationExpression="[0-9]+(\.[0-9]+)?" ValidationGroup="DetalleFooter">*</asp:RegularExpressionValidator>
														        </FooterTemplate>
														        <ItemStyle HorizontalAlign="Right" />
                                                                <HeaderStyle Font-Bold="False" Width="80px" />
													        </asp:TemplateField>
													        <asp:TemplateField HeaderText="Cantidad12" HeaderStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right">
														        <ItemTemplate>
															        <asp:Label ID="lblCantidad12" runat="server" Text='<%# Eval("Cantidad12") %>' Width="80px"></asp:Label>
														        </ItemTemplate>
														        <EditItemTemplate>
															        <asp:TextBox ID="txtCantidad12Edit" runat="server" Text='<%# Eval("Cantidad12") %>' Width="70px" SkinID="TextoBoxChico"></asp:TextBox><asp:RegularExpressionValidator
																        ID="cantidad12EditRegularExpressionValidator" runat="server" ControlToValidate="txtCantidad12Edit"
																        ErrorMessage="Cantidad del artículo en edición mal formateado" SetFocusOnError="true"
																        ValidationExpression="[0-9]+(\.[0-9]+)?" ValidationGroup="DetalleEditItem">*</asp:RegularExpressionValidator>
														        </EditItemTemplate>
														        <FooterTemplate>
															        <asp:TextBox ID="txtCantidad12" runat="server" Text='0' Width="70px" SkinID="TextoBoxChico"></asp:TextBox><asp:RegularExpressionValidator
																        ID="txtcantidad12FooterRegularExpressionValidator" runat="server" ControlToValidate="txtCantidad12"
																        ErrorMessage="Cantidad del artículo a agregar mal formateado" SetFocusOnError="true"
																        ValidationExpression="[0-9]+(\.[0-9]+)?" ValidationGroup="DetalleFooter">*</asp:RegularExpressionValidator>
														        </FooterTemplate>
														        <ItemStyle HorizontalAlign="Right" />
                                                                <HeaderStyle Font-Bold="False" Width="80px" />
													        </asp:TemplateField>  												        
                                                            <asp:TemplateField HeaderText="Cantidad13" HeaderStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right">
														        <ItemTemplate>
															        <asp:Label ID="lblCantidad13" runat="server" Text='<%# Eval("Cantidad13") %>' Width="80px"></asp:Label>
														        </ItemTemplate>
														        <EditItemTemplate>
															        <asp:TextBox ID="txtCantidad13Edit" runat="server" Text='<%# Eval("Cantidad13") %>' Width="70px" SkinID="TextoBoxChico"></asp:TextBox><asp:RegularExpressionValidator
																        ID="cantidad13EditRegularExpressionValidator" runat="server" ControlToValidate="txtCantidad13Edit"
																        ErrorMessage="Cantidad del artículo en edición mal formateado" SetFocusOnError="true"
																        ValidationExpression="[0-9]+(\.[0-9]+)?" ValidationGroup="DetalleEditItem">*</asp:RegularExpressionValidator>
														        </EditItemTemplate>
														        <FooterTemplate>
															        <asp:TextBox ID="txtCantidad13" runat="server" Text='0' Width="70px" SkinID="TextoBoxChico"></asp:TextBox><asp:RegularExpressionValidator
																        ID="txtcantidad13FooterRegularExpressionValidator" runat="server" ControlToValidate="txtCantidad13"
																        ErrorMessage="Cantidad del artículo a agregar mal formateado" SetFocusOnError="true"
																        ValidationExpression="[0-9]+(\.[0-9]+)?" ValidationGroup="DetalleFooter">*</asp:RegularExpressionValidator>
														        </FooterTemplate>
														        <ItemStyle HorizontalAlign="Right" />
                                                                <HeaderStyle Font-Bold="False" Width="80px" />
													        </asp:TemplateField>
													        <asp:TemplateField HeaderText="Cantidad14" HeaderStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right">
														        <ItemTemplate>
															        <asp:Label ID="lblCantidad14" runat="server" Text='<%# Eval("Cantidad14") %>' Width="80px"></asp:Label>
														        </ItemTemplate>
														        <EditItemTemplate>
															        <asp:TextBox ID="txtCantidad14Edit" runat="server" Text='<%# Eval("Cantidad14") %>' Width="70px" SkinID="TextoBoxChico"></asp:TextBox><asp:RegularExpressionValidator
																        ID="cantidad14EditRegularExpressionValidator" runat="server" ControlToValidate="txtCantidad14Edit"
																        ErrorMessage="Cantidad del artículo en edición mal formateado" SetFocusOnError="true"
																        ValidationExpression="[0-9]+(\.[0-9]+)?" ValidationGroup="DetalleEditItem">*</asp:RegularExpressionValidator>
														        </EditItemTemplate>
														        <FooterTemplate>
															        <asp:TextBox ID="txtCantidad14" runat="server" Text='0' Width="70px" SkinID="TextoBoxChico"></asp:TextBox><asp:RegularExpressionValidator
																        ID="txtcantidad14FooterRegularExpressionValidator" runat="server" ControlToValidate="txtCantidad14"
																        ErrorMessage="Cantidad del artículo a agregar mal formateado" SetFocusOnError="true"
																        ValidationExpression="[0-9]+(\.[0-9]+)?" ValidationGroup="DetalleFooter">*</asp:RegularExpressionValidator>
														        </FooterTemplate>
														        <ItemStyle HorizontalAlign="Right" />
                                                                <HeaderStyle Font-Bold="False" Width="80px" />
													        </asp:TemplateField>  												        
                                                            <asp:CommandField
														        HeaderText="Edici&#243;n" ShowEditButton="True" ValidationGroup="DetalleEditItem">
														        <ItemStyle HorizontalAlign="Center" Width="150px" />
                                                                <HeaderStyle Font-Bold="False" HorizontalAlign="Center" Width="150px" />
													        </asp:CommandField>
													        <asp:TemplateField HeaderText="Eliminaci&#243;n / Incorporaci&#243;n">
														        <ItemTemplate>
															        <asp:LinkButton ID="linkDeleteDetalle" runat="server" CausesValidation="false" CommandName="Delete"
																        Width="150px">Borrar</asp:LinkButton>
														        </ItemTemplate>
														        <FooterTemplate>
															        <asp:LinkButton ID="linkAddDetalle" runat="server" CausesValidation="true" CommandName="AddDetalle"
																        ValidationGroup="DetalleFooter" Width="150px">Agregar</asp:LinkButton>
														        </FooterTemplate>
														        <ItemStyle HorizontalAlign="Center" />
                                                                <HeaderStyle Font-Bold="False" Width="150px" />
													        </asp:TemplateField>
												        </Columns>
                                                        <RowStyle ForeColor="#071F70" />
                                                        <EmptyDataRowStyle ForeColor="#071F70" />
                                                        <PagerStyle ForeColor="#071F70" />
                                                        <SelectedRowStyle ForeColor="#071F70" />
                                                        <HeaderStyle ForeColor="Brown" />
                                                        <EditRowStyle ForeColor="#071F70" />
											        </asp:GridView>
										        </asp:Panel>
									        </ContentTemplate>
                                        </asp:UpdatePanel>
                                        <asp:ValidationSummary ID="GrillasValidationSummary" runat="server" BorderColor="Gray"
                                            BorderWidth="1px" HeaderText="Hay que ingresar o corregir los siguientes campos:"
                                            ShowMessageBox="True" ValidationGroup="DetalleEditItem" />
                                        
                                        <asp:ValidationSummary ID="FooterGrillasValidationSummary" runat="server" BorderColor="Gray"
                                            BorderWidth="1px" HeaderText="Hay que ingresar o corregir los siguientes campos:"
                                            ShowMessageBox="True" ValidationGroup="DetalleFooter" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="3" style="height: 10px;">
                                    </td>
                                </tr> 
                                <tr>
                                    <td colspan="3">
                                        <table border="0" cellpadding="0" cellspacing="0" id="Table1"> 
                                            <td style="width:190px">
                                            
                                                <asp:Button ID="AceptarButton" runat="server" OnClick="AceptarButton_Click" Text="Aceptar" Width="190px" />
                                            </td>
                                            <td style="width: 490px;">
                                            </td>
                                            <td style="width:190px">
                                                <asp:Button ID="CancelarButton" runat="server" OnClick="CancelarButton_Click" Text="Cancelar"
                                                    Width="190px" />
                                            </td>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 10px;">
                                    </td>
                                </tr>   
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:content>