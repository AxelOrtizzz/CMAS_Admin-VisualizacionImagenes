<%@ Page Title="Alta" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Alta.aspx.cs" Inherits="CallawayWeb.About" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1>.<%: Title %>.</h1>
        <h2>&nbsp;</h2>
    </hgroup>

    <article>
        <table class="auto-style2">
            <tr>
                <td class="auto-style28">
                    <asp:Panel ID="Login" runat="server">
                        <table class="auto-style2">
                            <tr>
                                <td align="right" style="width: 50%">Usuario:</td>
                                <td align="left">
                                    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">Password:</td>
                                <td align="left">
                                    <asp:TextBox ID="TextBox4" runat="server" TextMode="Password"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:Button ID="BtnLogin" runat="server" OnClick="BtnLogin_Click" Text="Ingresar" />
                                    <asp:Label ID="LbErrors0" runat="server" ForeColor="Red"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td class="auto-style28">
                    <asp:Panel ID="Panel1" runat="server" Visible="False">
                        <asp:Button ID="BtnModelo" runat="server" OnClick="BtnModelo_Click" Text="Modelo" />
                        <asp:Button ID="BtnPartes" runat="server" OnClick="Button2_Click" Text="Partes" />
                        <asp:Button ID="BtnLimites" runat="server" OnClick="BtnLimites_Click" Text="Límites" />
                        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click1" Text="Alta Límites Masivos" />
                        <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Alta Partes Masivas" />
                        <asp:Button ID="Button4" runat="server" OnClick="Button4_Click1" Text="Alta Producto-Partes Masivo" />
                        <asp:Button ID="Button8" runat="server" OnClick="Button8_Click" Text="Producto-Partes Individuales" />
                        <asp:Button ID="Button5" runat="server" OnClick="Button5_Click" Text="Alta Sets Masivo" />
                        <asp:Button ID="Button9" runat="server" OnClick="Button9_Click" Text="Sets Individuales" />
                        <br />
                        <asp:Label ID="LbAsociado0" runat="server"></asp:Label>
                        &nbsp;<asp:Label ID="LbAsociado" runat="server"></asp:Label>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td style="text-align: center">
                    <asp:Panel ID="AltaModelo" runat="server" Visible="False" DefaultButton="BtGuardaModelo">
                        <table class="auto-style2">
                            <tr>
                                <td class="TituloTabla" colspan="2">Alta de Modelos</td>
                            </tr>
                            <tr>
                                <td class="auto-style26">Modelo: </td>
                                <td class="auto-style27" colspan="1">
                                    <asp:TextBox ID="TxtModelo" runat="server" CssClass="TextBoxTabla" Height="14px" Width="254px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TxtModelo" ErrorMessage="Requiere definir el nombre del modelo." ValidationGroup="Grupo1">*</asp:RequiredFieldValidator>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ControlToValidate="TxtModelo" ErrorMessage="Indique el modelo" ValidationGroup="modelo">*</asp:RequiredFieldValidator>
                                    <asp:Button ID="Button6" runat="server" OnClick="Button6_Click" Text="Buscar" ValidationGroup="modelo" />
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style25">Descripción:</td>
                                <td class="auto-style29">
                                    <asp:TextBox ID="TxtModeloDesc" runat="server" CssClass="TextBoxTabla" Width="254px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TxtModeloDesc" ErrorMessage="Requiere una descripción del modelo." ValidationGroup="Grupo1">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style25">Modelo Or:</td>
                                <td class="auto-style29">
                                    <asp:TextBox ID="TxtModeloOr" runat="server" CssClass="TextBoxTabla" Width="254px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style25">Orden:</td>
                                <td class="auto-style29">
                                    <asp:TextBox ID="TxtModeloOrden" runat="server" CssClass="TextBoxTabla" Width="254px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:Button ID="BtGuardaModelo" runat="server" OnClick="BtGuardaModelo_Click" Text="Guardar" ValidationGroup="Grupo1"/>
                                    <asp:Button ID="BtnBorrarModelo" runat="server" OnClick="BtnBorrarModelo_Click" Text="Borrar" Visible="False" />
                                    <br />
                                    <asp:Label ID="LbErrorModelos" runat="server" ForeColor="Red"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2">
                                    <asp:GridView ID="GvModelos" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="GvModelos_SelectedIndexChanged">
                                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                        <Columns>
                                            <asp:CommandField ShowSelectButton="True" />
                                        </Columns>
                                        <EditRowStyle BackColor="#999999" />
                                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                        <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                        <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                        <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>


                    <asp:Panel ID="AltaPartes" runat="server" Visible="False" DefaultButton="BtGuardaParte">
                        <span class="TituloTabla">Alta de Partes</span>
                        <div id="mensajes" style="display:none; padding:10px; border-radius:5px;"></div>
                        <div style="display: flex;">
                            <div style="flex: 1; width: 65%;">
                                <table class="style2" >
                                    <tr>
                                        <td class="auto-style23">Categoría:</td>
                                        <td style="text-align: left" class="auto-style24">
                                            <asp:DropDownList ID="DDCategoría0" runat="server" Height="19px" OnSelectedIndexChanged="DDCategoría0_SelectedIndexChanged" style="margin-left: 0px" Width="140px" AutoPostBack="True">
                                                <asp:ListItem></asp:ListItem>
                                                <asp:ListItem>GRIP</asp:ListItem>
                                                <asp:ListItem>HD</asp:ListItem>
                                                <asp:ListItem>SF</asp:ListItem>
                                                <asp:ListItem Value="HC">HC</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="DDCategoría0" ErrorMessage="Seleccione una categoría." InitialValue="" ValidationGroup="Grupo2">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style23">Modelo:</td>
                                        <td class="auto-style24" style="text-align: left">
                                            <asp:DropDownList ID="DDModelos" runat="server" AppendDataBoundItems="True" AutoPostBack="True" Height="19px" OnSelectedIndexChanged="DDModelos_SelectedIndexChanged" style="margin-left: 0px" Width="140px">
                                                <asp:ListItem></asp:ListItem>
                                            </asp:DropDownList>
                                            &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="DDModelos" ErrorMessage="Seleccione un Modelo" InitialValue="" ValidationGroup="Grupo2">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style15">Parte:</td>
                                        <td style="text-align: left">
                                            <asp:TextBox ID="TxtParte" runat="server" CssClass="TextBoxTable" MaxLength="20" Height="19px" OnTextChanged="TxtParte_TextChanged"></asp:TextBox>
                                            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Buscar" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TxtParte" ErrorMessage="Introduzca el nombre de la parte." ValidationGroup="Grupo2">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style15">Descripción:</td>
                                        <td style="text-align: left">
                                            <asp:TextBox ID="__TxtParte0" runat="server" CssClass="TextBoxTable" ValidateRequestMode="Disabled" MaxLength="50" Height="19px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="__TxtParte0" ErrorMessage="Introduzca una descripción." ValidationGroup="Grupo2">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style15">
                                            <asp:Label ID="LbMano" runat="server" Text="Mano"></asp:Label>
                                        </td>
                                        <td style="text-align: left">
                                            <asp:DropDownList ID="DDRL" runat="server" Height="19px" style="margin-left: 0px" Width="140px">
                                                <asp:ListItem></asp:ListItem>
                                                <asp:ListItem>LH</asp:ListItem>
                                                <asp:ListItem>RH</asp:ListItem>
                                            </asp:DropDownList>
                                            &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="DDRL" ErrorMessage="Seleccione si es RH o LH" InitialValue="" ValidationGroup="Grupo2">*</asp:RequiredFieldValidator>
                                            <asp:TextBox ID="TxGrip" runat="server" MaxLength="5" Visible="False"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style15">
                                            <asp:Label ID="LbLongitud" runat="server" Text="Longitud:" Visible="False"></asp:Label>
                                        </td>
                                        <td style="text-align: left">
                                            <asp:TextBox ID="TxLongitud" runat="server" Visible="False"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style13">Número de Cabeza:</td>
                                        <td class="auto-style14" style="text-align: left">
                                            <asp:TextBox ID="TxtTipoParte" runat="server" CssClass="TextBoxTable" MaxLength="8" Height="19px"></asp:TextBox>
                                            &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="__TxtParte0" ErrorMessage="Defina el tipo de material." ValidationGroup="Grupo2">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style16">Material:</td>
                                        <td class="auto-style17" style="text-align: left">
                                            <asp:DropDownList ID="DDMaterial" runat="server" Height="19px" style="margin-left: 0px" Width="140px" AppendDataBoundItems="True">
                                                <asp:ListItem></asp:ListItem>
                                            </asp:DropDownList>
                                            &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="DDMaterial" ErrorMessage="Seleccione el material." InitialValue="" ValidationGroup="Grupo2">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style15">Dobla:</td>
                                        <td style="text-align: left">
                                            <asp:DropDownList ID="DDDobla" runat="server" Height="19px" style="margin-left: 0px" Width="140px">
                                                <asp:ListItem></asp:ListItem>
                                                <asp:ListItem Value="N">No</asp:ListItem>
                                                <asp:ListItem Value="Y">Si</asp:ListItem>
                                            </asp:DropDownList>
                                            &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="DDDobla" ErrorMessage="Seleccione si tiene doblez o no." InitialValue="" ValidationGroup="Grupo2">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style15">Género:</td>
                                        <td style="text-align: left">
                                            <asp:DropDownList ID="DDGenero" runat="server" AppendDataBoundItems="True">
                                                <asp:ListItem></asp:ListItem>
                                                <asp:ListItem>W</asp:ListItem>
                                                <asp:ListItem>M</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ControlToValidate="DDGenero" ErrorMessage="Indique el género" ValidationGroup="Grupo2">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td id="tdImagen" runat="server" class="auto-style15">Imagen:</td>
                                        <td style="text-align: left">
                                            <asp:FileUpload ID="FileUploadImagen" runat="server" onchange="validarImagen(this);" />
                                            <asp:Label ID="LbMensajeImagen" runat="server" ForeColor="Red"></asp:Label>
                                            <br />
                                            <asp:Image ID="ImgParte" runat="server" Width="200px" Height="200px" Visible="false" />
                                            <asp:Label ID="LblNoImagen" runat="server" ForeColor="Red" Text="No hay imagen disponible" Visible="false"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div style="flex: 0 0 auto; width: 40%; display: flex; justify-content: flex-start; align-items: flex-start;"> 
                                <img id="imagenPrevia" class="style-img" src="#" alt="" style="width: 400px; height: 200px; display: none;">
                                <p id="textoPlaceholder">Vista previa de la imagen</p>
                            </div>
                        </div>                      
                        <table colspan="2" class="auto-style12">
                                    <asp:Button ID="BtGuardaParte" runat="server" Text="Guardar" OnClick="BtGuardaParte_Click" ValidationGroup="Grupo2" />
                                    <asp:Button ID="BtnUpdateParte" runat="server" OnClick="BtnUpdateParte_Click" Text="Actualizar" Visible="False" />
                                    <asp:Button ID="BtnBorrarParte" runat="server" Text="Eliminar" OnClick="BtnBorrarParte_Click" Visible="False" />
                                    <caption>
                                        <br />
                                        <asp:Label ID="LbErrorPartes" runat="server" ForeColor="Red"></asp:Label>
                                        <br />
                                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" CellSpacing="3" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" Width="100%">
                                            <AlternatingRowStyle HorizontalAlign="Left" />
                                            <Columns>
                                                <asp:BoundField DataField="Parte" HeaderText="Parte" />
                                                <asp:BoundField DataField="Descripcion" HeaderText="Descripción" />
                                                <asp:BoundField DataField="RL" HeaderText="RL" />
                                                <asp:BoundField DataField="Modelo" HeaderText="Modelo" />
                                                <asp:BoundField DataField="Tipo" HeaderText="Número de Cabeza" />
                                                <asp:BoundField DataField="Material" HeaderText="Material" />
                                                <asp:BoundField DataField="Dobla" HeaderText="Dobla" />
                                                <asp:BoundField DataField="Categoria" HeaderText="Categoría" />
                                                <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
                                                <asp:BoundField DataField="WM" HeaderText="Género" />
                                                <asp:BoundField DataField="Parte" HeaderText="Imagen" />
                                                <asp:CommandField SelectText="Seleccionar" ShowSelectButton="True" />
                                            </Columns>
                                            <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                                            <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                                            <RowStyle BackColor="#DEDFDE" ForeColor="Black" HorizontalAlign="Left" />
                                            <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                                            <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                            <SortedAscendingHeaderStyle BackColor="#594B9C" />
                                            <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                            <SortedDescendingHeaderStyle BackColor="#33276A" />
                                        </asp:GridView>
                                        <br />
                                    </caption>
                                </table>
                    </asp:Panel>

                    <asp:Panel ID="AltaLimites" runat="server" Visible="False" DefaultButton="BtGuardaLimites">
                        <table class="auto-style2" cellpadding="0" cellspacing="0">
                            <tr>
                                <td colspan="2" class="auto-style22">Alta de Límites</td>
                            </tr>
                            <tr>
                                <td class="auto-style20">Modelo:</td>
                                <td class="auto-style19">
                                    <asp:DropDownList ID="DDModelos0" runat="server" AppendDataBoundItems="True" Height="19px" style="margin-left: 0px" Width="140px" AutoPostBack="True" OnSelectedIndexChanged="DDModelos0_SelectedIndexChanged">
                                        <asp:ListItem></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="Seleccione un Modelo" ValidationGroup="Grupo3" ControlToValidate="DDModelos0">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style20">
                                    <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="True" OnCheckedChanged="CheckBox1_CheckedChanged" />
                                    SKU</td>
                                <td class="auto-style19">
                                    <asp:TextBox ID="TxSKU" runat="server" Enabled="False" OnTextChanged="TxSKU_TextChanged"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ControlToValidate="TxSKU" ErrorMessage="Indique el SKU" ValidationGroup="Grupo3">*</asp:RequiredFieldValidator>
                                    <asp:Button ID="BtnBuscarLimites" runat="server" OnClick="BtnBuscarLimites_Click" Text="Buscar" />
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style20">Operación:</td>
                                <td class="auto-style19">
                                    <asp:DropDownList ID="DDOperaciones" runat="server" AppendDataBoundItems="True" Height="19px" style="margin-left: 0px" Width="140px" AutoPostBack="True" OnSelectedIndexChanged="DDOperaciones_SelectedIndexChanged">
                                        <asp:ListItem></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ErrorMessage="Seleccione la operación" ValidationGroup="Grupo3" ControlToValidate="DDOperaciones">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style20">Género:</td>
                                <td class="auto-style19">
                                    <asp:DropDownList ID="DDGeneroLim" runat="server" OnSelectedIndexChanged="DDGeneroLim_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ErrorMessage="Introduzca el género." ValidationGroup="Grupo3" ControlToValidate="DDGeneroLim">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style7">Número de Cabeza:</td>
                                <td class="auto-style5">
                                    <asp:TextBox ID="TxtTipoLim" runat="server" CssClass="TextBoxTabla" Height="19px" MaxLength="8"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ErrorMessage="Indique el tipo" ValidationGroup="Grupo3" ControlToValidate="TxtTipoLim">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style20">Descripción de Límite:</td>
                                <td class="auto-style19">
                                    <asp:DropDownList ID="DDdescLim" runat="server">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ErrorMessage="Describa el límite." ValidationGroup="Grupo3" ControlToValidate="DDdescLim">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style20">Límite (Decimal):</td>
                                <td class="auto-style19">
                                    <asp:TextBox ID="TxtLimDec" runat="server" CssClass="TextBoxTabla" Height="19px" MaxLength="14" OnTextChanged="TxtLimDec_TextChanged" AutoPostBack="True"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ErrorMessage="Introduzca el Limite (Decimal)" ValidationGroup="Grupo3" ControlToValidate="TxtLimDec">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style20">Límite (Fracción):</td>
                                <td class="auto-style19">
                                    <asp:TextBox ID="TxtLimFrac" runat="server" CssClass="TextBoxTabla" Height="19px" MaxLength="14"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" EnableTheming="True" ErrorMessage="Introduzca el límite (Fracción)" ValidationGroup="Grupo3" ControlToValidate="TxtLimFrac">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" class="auto-style21">
                                    <asp:Button ID="BtGuardaLimites" runat="server" Text="Guardar" OnClick="BtGuardaLimites_Click" ValidationGroup="Grupo3" />
                                    <asp:Button ID="BtnUpdateLimite" runat="server" OnClick="BtnUpdateLimite_Click" Text="Actualizar" Visible="False" ValidationGroup="Grupo3" />
                                    <asp:Button ID="BtnBorrarLimite" runat="server" OnClick="BtnBorrarLimite_Click" Text="Eliminar" Visible="False" ValidationGroup="Grupo3" />
                                    <asp:Button ID="Button7" runat="server" OnClick="Button7_Click" Text="Limpiar" />
                                    <br />
                                    <asp:Label ID="LbErrors" runat="server"></asp:Label>
                                    <br />
                                    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" CellSpacing="3" HorizontalAlign="Center" OnSelectedIndexChanged="GridView2_SelectedIndexChanged" Width="100%">
                                        <AlternatingRowStyle HorizontalAlign="Left" />
                                        <Columns>
                                            <asp:BoundField DataField="Modelo" HeaderText="Modelo" />
                                            <asp:BoundField DataField="operacion_id" HeaderText="Operación ID" />
                                            <asp:BoundField DataField="Operacion" HeaderText="Operación" />
                                            <asp:BoundField DataField="Genero" HeaderText="Genero" />
                                            <asp:BoundField DataField="Número de Cabeza" HeaderText="Número de Cabeza" />
                                            <asp:BoundField DataField="Límite" HeaderText="Límite" />
                                            <asp:BoundField DataField="Límite Decimal" HeaderText="Valor Decimal" />
                                            <asp:BoundField DataField="Límite Fracción" HeaderText="Valor Fracción" />
                                            <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
                                            <asp:CommandField SelectText="Seleccionar" ShowSelectButton="True" />
                                        </Columns>
                                        <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                                        <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                                        <RowStyle BackColor="#DEDFDE" ForeColor="Black" HorizontalAlign="Left" />
                                        <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                        <SortedAscendingHeaderStyle BackColor="#594B9C" />
                                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                        <SortedDescendingHeaderStyle BackColor="#33276A" />
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <br />
                    <br />
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="#CC0000" style="text-align: left" ValidationGroup="Grupo1" />
                    <asp:ValidationSummary ID="ValidationSummary2" runat="server" ForeColor="#CC0000" style="text-align: left" ValidationGroup="Grupo2" />
                    <asp:ValidationSummary ID="ValidationSummary3" runat="server" ForeColor="#CC0000" style="text-align: left" ValidationGroup="Grupo3"/>
                    <br />
                    <br />
                </td>
            </tr>
        </table>
    </article>
    <script type="text/javascript">
        function validarImagen(input) {
            const file = input.files[0];
            const labelError = document.getElementById('<%= LbMensajeImagen.ClientID %>');
            const imagenPrevia = document.getElementById('imagenPrevia');
            const textoPlaceholder = document.getElementById('textoPlaceholder');

            if (file) {
                const fileType = file.type;

                if (fileType.startsWith('image/')) {
                    labelError.textContent = '';

                    const lector = new FileReader();
                    lector.addEventListener('load', function () {
                        // Mostrar la imagen seleccionada en la vista previa
                        imagenPrevia.src = this.result; // Mostrar en <img>
                        imagenPrevia.style.display = 'block'; // Hacer visible la imagen
                        textoPlaceholder.style.display = 'none'; // Ocultar el texto de placeholder
                    });

                    lector.readAsDataURL(file);
                } else {
                    labelError.textContent = 'Error: Solo se permiten archivos de imagen.';
                    input.value = '';
                    imagenPrevia.src = '#';
                    imagenPrevia.style.display = 'none';
                    textoPlaceholder.style.display = 'block'; // Mostrar el texto de placeholder

                    setTimeout(function () {
                        {
                            labelError.style.display = 'none';
                            
                        }
                    }, 5000);
                }
            } else {
                labelError.textContent = '';
                imagenPrevia.src = '#';
                imagenPrevia.style.display = 'none';
                textoPlaceholder.style.display = 'block'; // Mostrar el texto de placeholder
            }
        }

        function mostrarImagen(imageUrl) {
            var img = document.getElementById("imagenPrevia");
            var placeholder = document.getElementById("textoPlaceholder");

            // Convertir la ruta relativa a una ruta absoluta
            var absoluteUrl = new URL(imageUrl, window.location.origin).href;

            img.src = absoluteUrl; // Asignar la URL de la imagen
            img.style.display = "block"; // Mostrar la imagen
            placeholder.style.display = "none"; // Ocultar mensaje de error
        }

        function mostrarTexto() {
            var img = document.getElementById("imagenPrevia");
            var placeholder = document.getElementById("textoPlaceholder");

            img.style.display = "none"; // Oculta la imagen
            placeholder.textContent = "No hay imagen disponible"; // Mensaje de error
            placeholder.style.display = "block"; // Mostrar mensaje de error
        }



    
        setInterval(function () {
            eliminarImagenes();
        }, 30000); // Ejecuta cada 30 segundos

        function eliminarImagenes() {
            fetch('Alta.aspx/EliminarImagenes', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify({})
            })
                .then(response => response.json())
                .then(data => console.log("Imágenes eliminadas"))
                .catch(error => console.error("Error eliminando imágenes", error));
        }

        


    </script>



</asp:Content>
<asp:Content ID="Content1" runat="server" contentplaceholderid="HeadContent">
    
    <style type="text/css">
        td {
            table-layout: auto;4
        }
        .auto-style2 {
            width: 100%;
        }
        table.style2 {
            width: 100%;
        }
                        
        .auto-style5 {
            height: 23px;
            text-align: left;
        }
        
        .auto-style7 {
            height: 23px;
            width: 499px;
            text-align: right;
        }
                
        .auto-style12 {
            text-align: center;
            width: 100%;
        }

        .auto-style13 {
            text-align: left;
            width: 484px;
            height: 16px;
        }
        .auto-style14 {
            height: 24px;
        }
        .auto-style15 {
            text-align: left;
            width: 484px;
            height: 16px;
        }
        .auto-style16 {
            text-align: left;
            width: 484px;
            height: 16px;
        }
        .auto-style17 {
            height: 26px;
        }

                
        .auto-style19 {
            text-align: left;
        }
        .auto-style20 {
            width: 499px;
            text-align: right;
        }
        .auto-style21 {
            text-align: center;
        }
        .auto-style22 {
            font-family: Arial, Helvetica, sans-serif;
            font-size: medium;
            font-weight: bold;
            text-align: center;
        }
        .auto-style23 {
            text-align: left;
            width: 484px;
            height: 16px;
        }
        .auto-style24 {
            width: 75%;
            height: 16px;
        }
        
        .auto-style25 {
            text-align: right;
            width: 484px;
            height: 29px;
        }
        
        .auto-style26 {
            text-align: right;
            width: 484px;
            height: 26px;
        }
        .auto-style27 {
            text-align: left;
            height: 26px;
        }

        .style-img{
            width: 400px;
            height: 200px;
        }
        
        .auto-style28 {
            height: 34px;
        }
        
        .auto-style29 {
            text-align: left;
            height: 29px;
        }
        
    </style>
</asp:Content>


