using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;
using System.IO;
using System.Diagnostics;
using System.Web.Services;


namespace CallawayWeb
{
    public partial class About : Page
    {
        static string ViejaCabeza = "";
        static string ViejoGenero = ""; 
        static string sharedFolderPath = @"\\cgmfs402\Tracebility\Images\";
        protected void Page_Load(object sender, EventArgs e)
        {

            

            if (!IsPostBack)
            {
                CargaCombosPartes();
                RequiredFieldValidator20.Enabled = false;
                BtGuardaParte.Visible = false;
                FileUploadImagen.Visible = true;
                LbMensajeImagen.Visible = true;
                tdImagen.Visible = true;

                

            }
        }

        protected void MostrarMensaje(string mensaje, bool esExito)
        {
            string tipoMensaje = esExito ? "success" : "error";

            string script = $@"
                var mensajeElemento = document.getElementById('mensajes');
                mensajeElemento.innerText = '{mensaje}';
                mensajeElemento.style.color = '{(esExito ? "green" : "red")}';
                mensajeElemento.style.display = 'block';

                setTimeout(function() {{
                    mensajeElemento.style.display = 'none';
                    }}, 5000);
                ";

            ScriptManager.RegisterStartupScript(this, this.GetType(), "mostrarMensaje", script, true);
        }




        [WebMethod]
        public static void EliminarImagenes()
        {
            try
            {
                string folderPath = System.Web.HttpContext.Current.Server.MapPath("~/Content/imgServidor/");

                if (Directory.Exists(folderPath))
                {
                    string[] archivos = Directory.GetFiles(folderPath, "*.*")
                                                 .Where(s => s.EndsWith(".jpg") || s.EndsWith(".jpeg") || s.EndsWith(".png") || s.EndsWith(".gif"))
                                                 .ToArray();

                    foreach (string archivo in archivos)
                    {
                        File.Delete(archivo);
                    }
                }
            }
            catch (Exception ex)
            {
                // Puedes registrar el error si lo deseas
                System.Diagnostics.Debug.WriteLine("Error eliminando imágenes: " + ex.Message);
            }
        }


        protected void BtnModelo_Click(object sender, EventArgs e)
        {
            AltaModelo.Visible = true;
            AltaPartes.Visible = false;
            AltaLimites.Visible = false;
            BtGuardaParte.Visible = true;
            BtnUpdateParte.Visible = false;
            BtnBorrarParte.Visible = false;
            LbErrors.Text = "";
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            // Hacer visibles/invisibles los formularios y botones correspondientes
            AltaModelo.Visible = false;
            AltaPartes.Visible = true;
            AltaLimites.Visible = false;
            BtGuardaParte.Visible = true;
            BtnUpdateParte.Visible = false;
            BtnBorrarParte.Visible = false;
            BtGuardaLimites.Visible = false;
            BtnBorrarLimite.Visible = true;
            BtnUpdateLimite.Visible = true;

            // Limpiar los campos de texto en el formulario "Partes"
            TxtParte.Text = "";
            __TxtParte0.Text = ""; // Limpiar el campo de descripción
            TxtTipoParte.Text = "";
            TxGrip.Text = "";
            TxLongitud.Text = "";

            // Limpiar los DropDowns
            DDCategoría0.SelectedIndex = 0; // Limpiar Dropdown de Categoría
            DDModelos.SelectedIndex = 0;    // Limpiar Dropdown de Modelos
            DDRL.SelectedIndex = 0;         // Limpiar Dropdown de Mano
            DDMaterial.SelectedIndex = 0;   // Limpiar Dropdown de Material
            DDDobla.SelectedIndex = 0;      // Limpiar Dropdown de Dobla
            DDGenero.SelectedIndex = 0;     // Limpiar Dropdown de Género

            // Limpiar la imagen
            ImgParte.ImageUrl = ""; // Eliminar la imagen
            ImgParte.Visible = false;

            // Limpiar el label de errores
            LbErrors.Text = "";
            ViewState.Clear();
        }



        protected void BtnLimites_Click(object sender, EventArgs e)
        {
            AltaModelo.Visible = false;
            AltaPartes.Visible = false;
            AltaLimites.Visible = true;
            BtGuardaLimites.Visible = true;
            BtnBorrarLimite.Visible = false;
            BtnUpdateLimite.Visible = false;
            LbErrors.Text = "";
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
        }

        protected void BtGuardaModelo_Click(object sender, EventArgs e)
        {
            LbErrors.Text = "";
            SQL sql = new SQL();
            sql.Base();
            sql.AddParameter("@Modelo",TxtModelo.Text);
            sql.AddParameter("@descripcion", TxtModeloDesc.Text);
            sql.AddParameter("@ModeloOr",TxtModeloOr.Text);
            sql.AddParameter("@Orden", TxtModeloOrden.Text);
            sql.SpMat_SetRequi();
            LbErrors.Text = sql.Errors;
            if (LbErrors.Text == "")
            {
                CargaGridModelos();
                TxtModelo.Text = "";
                TxtModeloDesc.Text = "";
                LbErrors.Text = "";
                TxtModeloOr.Text = "";
                TxtModeloOrden.Text = "";
                LbErrors.Text = "Modelo guardado con éxito.";
            }
        }

        protected void BtGuardaParte_Click(object sender, EventArgs e)
        {
            LbErrors.Text = "";
            SQL sql = new SQL();
            sql.Base();

            // Parámetros
            sql.AddParameter("@ParteId", TxtParte.Text);
            sql.AddParameter("@Parte_Desc", __TxtParte0.Text);

            if (string.Equals(DDCategoría0.SelectedValue, "SF"))
                sql.AddParameter("@RL", TxLongitud.Text);
            else if (string.Equals(DDCategoría0.SelectedValue, "GRIP"))
                sql.AddParameter("@RL", TxGrip.Text);
            else
                sql.AddParameter("@RL", DDRL.SelectedValue);

            sql.AddParameter("@Modelo_id", DDModelos.SelectedValue);
            sql.AddParameter("@Tipo", TxtTipoParte.Text);
            sql.AddParameter("@Material", DDMaterial.SelectedValue);
            sql.AddParameter("@Dobla", DDDobla.SelectedValue);
            sql.AddParameter("@Categoría", DDCategoría0.SelectedValue);
            sql.AddParameter("@Genero", DDGenero.SelectedValue);

            // Guardar la imagen en la carpeta compartida
            try
            {
                if (FileUploadImagen.HasFile && FileUploadImagen.FileContent.Length > 0)
                {
                    string fileExtension = Path.GetExtension(FileUploadImagen.FileName).ToLower();
                    if (fileExtension != ".jpg" && fileExtension != ".jpeg" && fileExtension != ".png" && fileExtension != ".gif")
                    {
                        MostrarMensaje("Error: Solo se permiten imágenes en formato JPG, PNG o GIF.", false);
                        return;
                    }

                    // Nombre del archivo basado en el ID de la parte
                    string fileName = $"{TxtParte.Text}.jpg";
                    string fullPath = Path.Combine(sharedFolderPath, fileName);

                    // Guardar la imagen en la carpeta compartida
                    FileUploadImagen.SaveAs(fullPath);
                }
            }
            catch (Exception ex)
            {
                MostrarMensaje("Error al guardar la imagen: " + ex.Message, false);
                return;
            }

            // Ejecutar procedimiento almacenado
            sql.SpMat_SetPartes();
            LbErrors.Text = sql.Errors;

            if (string.IsNullOrEmpty(LbErrors.Text))
            {
                ClearPartes();
                MostrarMensaje("Parte guardada con éxito.", true);
                CargaGridPartes();
            }
            else
            {
                MostrarMensaje($"Error al guardar la parte: {LbErrors.Text}", false);
            }

        }







        protected void BtGuardaLimites_Click(object sender, EventArgs e)
        {
            int cont=0;
            if (CheckBox1.Checked)
            {
                //SQL sql1 = new SQL();
                //sql1.Base();
                //sql1.AddParameter("@SKU", TxSKU.Text);
                //DataSet ds = sql1.SpWeb_GetSKUexiste();
                // cont = Convert.ToInt32(ds.Tables[0].Rows[0]["contador"].ToString());
                cont = 1;
            }
            if ((CheckBox1.Checked & cont > 0) || (CheckBox1.Checked == false))
            {
                LbErrors.Text = "";
                SQL sql = new SQL();
                sql.Base();
                if (CheckBox1.Checked)
                    sql.AddParameter("@Modelo_id", TxSKU.Text);
                else
                    sql.AddParameter("@Modelo_id", DDModelos0.SelectedValue);
                sql.AddParameter("@Operation_id", DDOperaciones.SelectedValue);
                sql.AddParameter("@Genero", DDGeneroLim.SelectedValue);
                sql.AddParameter("@Tipo", TxtTipoLim.Text);

                sql.AddParameter("@Limite_desc", DDdescLim.SelectedValue);
                sql.AddParameter("@Limite_valor_dec", TxtLimDec.Text);
                sql.AddParameter("@Limite_valor_frac", TxtLimFrac.Text);
                sql.SpMat_SetLimites();
                LbErrors.Text = sql.Errors;
            }
            else
                LbErrors.Text = "SKU no existe";
            if (LbErrors.Text == "")
            {
                ClearLimites();
                LbErrors.Text = "Límite guardada con éxito.";
                CargaGridLimites();
            }
        }
        private void ClearLimites()
        {
            TxSKU.Text = "";
            DDModelos0.SelectedIndex = 0;
            DDOperaciones.SelectedIndex = 0;
            DDGeneroLim.Items.Clear();
            TxtTipoLim.Text = "";
            DDdescLim.Items.Clear();
            TxtLimDec.Text = "";
            TxtLimFrac.Text = "";
            BtGuardaLimites.Visible = true;
            BtnUpdateLimite.Visible = false;
            BtnBorrarLimite.Visible=true;
            LbErrorPartes.Text = "";
            //CargaCombosPartes();
        }
        private void ClearPartes()
        {
            DDCategoría0.SelectedIndex = 0;
            TxLongitud.Text = "";
            TxtParte.Text = "";
            __TxtParte0.Text = "";
            DDRL.SelectedIndex = 0;
            TxtTipoParte.Text = "";
            DDMaterial.SelectedIndex = 0;
            DDDobla.SelectedIndex = 0;
            LbErrorPartes.Text = "";
            TxGrip.Text = "";
            TxGrip.Visible = false;

            // Limpiar el campo de carga de archivos (FileUpload)
            FileUploadImagen.Attributes.Clear();

            // Ocultar la imagen de vista previa y mostrar el mensaje de "No hay imagen disponible"
            ScriptManager.RegisterStartupScript(this, this.GetType(), "resetImage",
                "document.getElementById('imagenPrevia').style.display = 'none';" +
                "document.getElementById('textoPlaceholder').textContent = 'No hay imagen disponible';" +
                "document.getElementById('textoPlaceholder').style.display = 'block';", true);
        }


        private void CargaCombosPartes()
        {
            CargaModelos();
            CargaModelos1();
            CargaMateriales();
            CargaOperaciones();

        }

        private void CargaModelos()
        {
            SQL sql = new SQL();
            sql.Base();
            DDModelos.DataSource = sql.SpWeb_GetModelos();
            DDModelos.DataTextField = "Modelo_Id";
            DDModelos.DataValueField = "Modelo_Id";
            DDModelos.DataBind();
            DDModelos.SelectedIndex= 0;
            
        }

        private void CargaModelos1()
        {
            SQL sql = new SQL();
            sql.Base();
            DDModelos0.DataSource = sql.SpWeb_GetModelos();
            DDModelos0.DataTextField = "Modelo_Id";
            DDModelos0.DataValueField = "Modelo_Id";
            DDModelos0.DataBind();
            DDModelos0.SelectedIndex = 0;

        }
        private void CargaMateriales()
        {
          /*  SQL sql = new SQL();
            sql.Base();
            DDMaterial.DataSource = sql.SpWeb_GetMateriales();
            DDMaterial.DataTextField = "Material";
            DDMaterial.DataValueField = "Material";
            DDMaterial.DataBind();*/
            ListItem l = new ListItem("ST", "ST", true);
            DDMaterial.Items.Add(l);
            ListItem l1 = new ListItem("GR", "GR", true);
            DDMaterial.Items.Add(l1);
            ListItem l2 = new ListItem("IR", "IR", true);
            DDMaterial.Items.Add(l2);
            ListItem l3 = new ListItem("PT", "PT", true);
            DDMaterial.Items.Add(l3);
            ListItem l4 = new ListItem("WD", "WD", true);
            DDMaterial.Items.Add(l4);
        }
        private void CargaOperaciones()
        {
            SQL sql = new SQL();
            sql.Base();
            DDOperaciones.DataSource = sql.SpWeb_GetOperaciones();
            DDOperaciones.DataTextField = "Operacion_desc";
            DDOperaciones.DataValueField = "Operacion_id";
            DDOperaciones.DataBind();

        }
        private void CargaGridPartes()
        {
            SQL sql = new SQL();
            sql.Base();
            sql.AddParameter("@Categoria", DDCategoría0.SelectedValue);
            GridView1.DataSource = sql.SpWeb_GetPartes();
            GridView1.DataBind();
            LbErrorPartes.Text = "";
        }
        protected void DDModelos_SelectedIndexChanged(object sender, EventArgs e)
        {
            //CargaGridPartes();
            //TxtParte.Text = "";
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            LbErrors.Text = GridView1.SelectedIndex.ToString();
            DDCategoría0.SelectedValue = GridView1.SelectedRow.Cells[7].Text;
            if (string.Equals(DDCategoría0.SelectedValue, "HD"))
            {
                if (GridView1.SelectedRow.Cells[3].Text == "&nbsp;" || GridView1.SelectedRow.Cells[3].Text == "  ")
                    DDModelos.SelectedIndex = 0;
                else
                    DDModelos.SelectedValue = GridView1.SelectedRow.Cells[3].Text.Trim().ToUpper();
                if (GridView1.SelectedRow.Cells[2].Text == "&nbsp;" || GridView1.SelectedRow.Cells[2].Text == "  ")
                    DDMaterial.SelectedIndex = 0;
                else
                    DDRL.Text = GridView1.SelectedRow.Cells[2].Text.Trim().ToUpper();
                TxtTipoParte.Text = GridView1.SelectedRow.Cells[4].Text.Trim();
                DDDobla.SelectedValue = GridView1.SelectedRow.Cells[6].Text.Trim().ToUpper();
            }
            TxtParte.Text = GridView1.SelectedRow.Cells[0].Text.Trim();
            __TxtParte0.Text = GridView1.SelectedRow.Cells[1].Text.Trim();

            if (string.Equals(DDCategoría0.SelectedValue, "GRIP"))
            {
                TxtTipoParte.Text = GridView1.SelectedRow.Cells[4].Text.Replace("&nbsp;", "");
                TxGrip.Visible = true;
                TxGrip.Text = GridView1.SelectedRow.Cells[2].Text.Trim();
            }
            if (string.Equals(DDCategoría0.SelectedValue, "SF") || string.Equals(DDCategoría0.SelectedValue, "HD"))
            {
                if (GridView1.SelectedRow.Cells[5].Text == "&nbsp;" || GridView1.SelectedRow.Cells[5].Text == "  ")
                    DDMaterial.SelectedIndex = 0;
                else
                    DDMaterial.SelectedValue = GridView1.SelectedRow.Cells[5].Text.Trim();
                TxLongitud.Text = GridView1.SelectedRow.Cells[2].Text.Trim();
            }
            if (GridView1.SelectedRow.Cells[9].Text == "&nbsp;" || GridView1.SelectedRow.Cells[9].Text == "  ")
                DDGenero.SelectedIndex = 0;
            else
                DDGenero.Text = GridView1.SelectedRow.Cells[9].Text.Trim();

            BtGuardaParte.Visible = false;
            BtnUpdateParte.Visible = true;
            BtnBorrarParte.Visible = true;
            IdentificaCatParte();
            LbErrorPartes.Text = "";

            try
            {
                
                // Nombre del archivo de imagen
                string fileName = TxtParte.Text + ".jpg";
                string sharedImagePath = Path.Combine(sharedFolderPath, fileName);

                // Ruta de la carpeta en el proyecto (Content/imgServidor)
                string projectImagePath = Server.MapPath("~/Content/imgServidor/" + fileName);

                // Si la imagen ya existe en la carpeta del proyecto, eliminarla antes de copiar
                if (File.Exists(projectImagePath))
                {
                    File.Delete(projectImagePath);
                }

                // Copiar la imagen desde la carpeta compartida
                File.Copy(sharedImagePath, projectImagePath, true); // Sobrescribir si ya existe

                // Generar la URL relativa con un parámetro para evitar caché
                string imageUrl = $"/Content/imgServidor/{fileName}?cache_bust=" + DateTime.Now.Ticks.ToString();

                // Actualizar la imagen en la página
                ScriptManager.RegisterStartupScript(this, this.GetType(), "mostrarImagen", $"mostrarImagen('{imageUrl}');", true);
            }
            catch (Exception ex)
            {
                LbErrors.Text = "Error al cargar la imagen: " + ex.Message;
            }



        }



        protected void DDModelos0_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargaGridLimites();
        }
        private void CargaGridLimites()
        {
            SQL sql = new SQL();
            sql.Base();
            if (CheckBox1.Checked)
                sql.AddParameter("@Modelo", TxSKU.Text);
            else
                sql.AddParameter("@Modelo", DDModelos0.SelectedValue);
            sql.AddParameter("@Operacion", DDOperaciones.SelectedValue);
            GridView2.DataSource = sql.SpWeb_GetLimites();
            GridView2.DataBind();
            LbErrorPartes.Text = "";
        }


        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {if (CheckBox1.Checked==false)
            DDModelos0.SelectedValue = GridView2.SelectedRow.Cells[0].Text.ToString().Trim().ToUpper();
        else
            TxSKU.Text = GridView2.SelectedRow.Cells[0].Text.ToString().Trim();
            DDOperaciones.SelectedValue = GridView2.SelectedRow.Cells[1].Text.ToString().Trim();
            OperacionCambia();
            DDGeneroLim.SelectedValue = GridView2.SelectedRow.Cells[3].Text.ToString().Trim();
            ViejoGenero = GridView2.SelectedRow.Cells[3].Text.ToString().Trim();
            TxtTipoLim.Text = GridView2.SelectedRow.Cells[4].Text;
            ViejaCabeza = GridView2.SelectedRow.Cells[4].Text;
            DDdescLim.SelectedValue = GridView2.SelectedRow.Cells[5].Text.ToString().Trim().ToUpper();
            TxtLimDec.Text = GridView2.SelectedRow.Cells[6].Text;
            TxtLimFrac.Text = GridView2.SelectedRow.Cells[7].Text;
            BtGuardaLimites.Visible = false;
            BtnBorrarLimite.Visible = true;
            BtnUpdateLimite.Visible = true;
            LbErrorPartes.Text = "";
        }

        protected void BorraLimite()
        {
            SQL sql = new SQL();
            sql.Base();

            if (CheckBox1.Checked)
                sql.AddParameter("@modelo", TxSKU.Text);
            else
            sql.AddParameter("@Modelo", DDModelos0.SelectedValue);
            sql.AddParameter("@Operacion_id", DDOperaciones.SelectedValue);
            sql.AddParameter("@Limite_desc", DDdescLim.SelectedValue);
            sql.AddParameter("@genero", DDGeneroLim.SelectedValue);

            sql.AddParameter("@cabeza", TxtTipoLim.Text);
            sql.SpWeb_DelLimite();
            CargaGridLimites();
            LbErrorPartes.Text = "";
        }

        protected void IdentificaCatParte()
        {
            if (String.ReferenceEquals(DDCategoría0.SelectedValue, "HD"))
            {
                DDRL.Enabled = true;
                RequiredFieldValidator7.Enabled = true;
                DDModelos.Enabled = true;
                RequiredFieldValidator6.Enabled = true;
                TxtTipoParte.Enabled = true;
                RequiredFieldValidator5.Enabled = true;
                DDMaterial.Enabled = true;
                //DDMaterial.SelectedValue = "";
                RequiredFieldValidator8.Enabled = false;
                DDDobla.Enabled = true;
                RequiredFieldValidator9.Enabled = true;
                LbLongitud.Visible = false;
                TxLongitud.Visible = false;
            }
            if (String.ReferenceEquals(DDCategoría0.SelectedValue, "GRIP"))
            {
                DDRL.Enabled = false;
                DDRL.SelectedValue = "";
                RequiredFieldValidator7.Enabled = false;
                DDModelos.Enabled = false;
                DDModelos.SelectedValue = "";
                RequiredFieldValidator6.Enabled = false;
                TxtTipoParte.Enabled = true;
                //TxtTipoParte.Text = "";
                RequiredFieldValidator5.Enabled = false;
                DDMaterial.Enabled = false;
                DDMaterial.SelectedValue = "";
                RequiredFieldValidator8.Enabled = false;
                DDDobla.Enabled = false;
                DDDobla.SelectedValue = "";
                RequiredFieldValidator9.Enabled = false;
                LbLongitud.Visible = false;
                TxLongitud.Visible = false;
            }
            if (String.ReferenceEquals(DDCategoría0.SelectedValue, "SF"))
            {
                DDRL.Enabled = false;

                RequiredFieldValidator7.Enabled = false;
                DDModelos.Enabled = false;
                RequiredFieldValidator6.Enabled = false;
                TxtTipoParte.Enabled = true;
                RequiredFieldValidator5.Enabled = false;
                DDMaterial.Enabled = true;
                RequiredFieldValidator8.Enabled = true;
                DDDobla.Enabled = false;
                RequiredFieldValidator9.Enabled = false;
                LbLongitud.Visible = true;
                TxLongitud.Visible = true;
                RequiredFieldValidator19.Enabled = false;
            }
            if (String.ReferenceEquals(DDCategoría0.SelectedValue, "HC"))
            {
                DDRL.Enabled = false;

                RequiredFieldValidator7.Enabled = false;
                DDModelos.Enabled = false;
                RequiredFieldValidator6.Enabled = false;
                TxtTipoParte.Enabled = false;
                RequiredFieldValidator5.Enabled = false;
                DDMaterial.Enabled = false;
                RequiredFieldValidator8.Enabled = false;
                DDDobla.Enabled = false;
                RequiredFieldValidator9.Enabled = false;
                LbLongitud.Visible = false;
                TxLongitud.Visible = false;
            }
        }
        protected void DDCategoría0_SelectedIndexChanged(object sender, EventArgs e)
        {

            ClearlodemasPartes();
            IdentificaCatParte();
            CargaGridPartes();
        }
        private void ClearlodemasPartes() {
            TxtParte.Text = "";
            __TxtParte0.Text="";
        }
        private void CargaGridPartesXParte()
        {
            SQL sql = new SQL();
            sql.Base();
            sql.AddParameter("@Parte", TxtParte.Text);
            GridView1.DataSource = sql.SpWeb_GetPartePorParte();
            GridView1.DataBind();

            if (GridView1.Rows.Count > 0)
            {
                // Si la parte existe, muestra los campos
                BtGuardaParte.Visible = false;
                BtnUpdateParte.Visible = false;
                BtnBorrarParte.Visible = false;
            }
            else
            {
                // Si no se encuentra la parte
                LbMensajeImagen.Visible = true;
                BtGuardaParte.Visible = true;
            }
            
                
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            __TxtParte0.Text = "";
            DDModelos.SelectedIndex = 0;
            DDRL.SelectedIndex = 0;
            TxtTipoParte.Text = "";
            DDMaterial.SelectedIndex = 0;
            DDDobla.SelectedIndex = 0;
            BtGuardaParte.Visible = true;
            BtnUpdateParte.Visible = false;
            BtnBorrarParte.Visible = false;

            // Recargar la grilla
            CargaGridPartesXParte();

            // Limpiar mensajes previos
            LbErrors.Text = "";

            try
            {
                // Verificar que se haya ingresado una parte
                if (string.IsNullOrWhiteSpace(TxtParte.Text))
                {
                    MostrarMensaje("Por favor, ingrese una parte antes de buscar.", false);
                    return;
                }

                // Nombre del archivo basado en la parte ingresada
                string fileName = TxtParte.Text.Trim() + ".jpg";

                // Ruta de la carpeta compartida
                string sharedImagePath = Path.Combine(sharedFolderPath, fileName);

                // Ruta de la carpeta local donde se guardará la imagen
                string localFolderPath = Server.MapPath("~/Content/imgServidor/");
                string localImagePath = Path.Combine(localFolderPath, fileName);

                // Verificar si la imagen existe en la carpeta compartida
                if (!File.Exists(sharedImagePath))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "mostrarMensaje",
                        "document.getElementById('imagenPrevia').style.display = 'none';" +
                        "document.getElementById('textoPlaceholder').innerText = 'No hay imagen disponible';", true);

                    MostrarMensaje("No hay imagen disponible.", false);
                    return;
                }

                // Si la imagen ya existe en la carpeta local, eliminarla antes de copiar
                if (File.Exists(localImagePath))
                {
                    File.Delete(localImagePath);
                }

                // Copiar la imagen desde la carpeta compartida
                File.Copy(sharedImagePath, localImagePath, true);

                // Generar la URL relativa con un parámetro de caché para evitar que el navegador utilice la versión en caché
                string imageUrl = $"Content/imgServidor/{fileName}?cache_bust=" + DateTime.Now.Ticks.ToString();

                // Actualizar la imagen en la página con JavaScript
                ScriptManager.RegisterStartupScript(this, this.GetType(), "mostrarImagen",
                    $"document.getElementById('imagenPrevia').src = '{imageUrl}';" +
                    "document.getElementById('imagenPrevia').style.display = 'block';" +
                    "document.getElementById('textoPlaceholder').innerText = '';", true);

            }
            catch (Exception ex)
            {
                MostrarMensaje("Error al buscar la imagen: " + ex.Message, false);
            }

        }




        protected void TxtParte_TextChanged(object sender, EventArgs e)
        {

        }

        protected void BtnUpdateParte_Click(object sender, EventArgs e)
        {
            SQL sql = new SQL();
            sql.Base();

            // Actualiza los parámetros de los campos del formulario
            sql.AddParameter("@parte", TxtParte.Text);
            sql.AddParameter("@desc", __TxtParte0.Text);

            if (string.Equals(DDCategoría0.SelectedValue, "SF"))
                sql.AddParameter("@rl", TxLongitud.Text);
            else if (string.Equals(DDCategoría0.SelectedValue, "GRIP"))
                sql.AddParameter("@RL", TxGrip.Text);
            else
                sql.AddParameter("@rl", DDRL.SelectedValue);

            sql.AddParameter("@modelo", DDModelos.SelectedValue);
            sql.AddParameter("@tipo", TxtTipoParte.Text);
            sql.AddParameter("@material", DDMaterial.Text);
            sql.AddParameter("@dobla", DDDobla.Text);
            sql.AddParameter("@categoria", DDCategoría0.SelectedValue);
            sql.AddParameter("@genero", DDGenero.SelectedValue);

            sql.SpWeb_UpdtPartes();

            if (FileUploadImagen.HasFile)
            {
                try
                {
                    string fileName = TxtParte.Text + ".jpg";
                    string imagePath = Path.Combine(@"\\cgmfs402\Tracebility\Images\", fileName);
                    string backupPath = Path.Combine(@"\\cgmfs402\Tracebility\Images\ImagesUpd\", fileName);

                    ClearPartes();

                    // Verifica si la carpeta es accesible
                    if (!Directory.Exists(@"\\cgmfs402\Tracebility\Images\"))
                    {
                        MostrarMensaje("La carpeta de imágenes no está disponible.", false);
                        return;
                    }

                    try
                    {
                        // Intenta eliminar la imagen existente
                        if (File.Exists(imagePath))
                        {
                            File.Delete(imagePath);
                        }

                        // Guarda la nueva imagen en la carpeta principal
                        FileUploadImagen.SaveAs(imagePath);

                        // Verifica si la imagen se guardó correctamente
                        if (File.Exists(imagePath))
                        {
                            MostrarMensaje("Imagen actualizada correctamente.", true);
                            ImgParte.ImageUrl = imagePath + "?cache_bust=" + DateTime.Now.Ticks.ToString();
                        }
                        else
                        {
                            MostrarMensaje("No se pudo guardar la imagen en la ruta principal.", false);
                        }
                    }
                    catch (IOException)
                    {
                        // Si la imagen está en uso, guárdala en la carpeta temporal
                        FileUploadImagen.SaveAs(backupPath);

                        if (File.Exists(backupPath))
                        {
                            MostrarMensaje("La imagen está en uso en producción. Se guardó temporalmente y se actualizará más tarde.", true);
                        }
                        else
                        {
                            MostrarMensaje("Error al guardar la imagen en la carpeta temporal.", false);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MostrarMensaje("Error al guardar la imagen: " + ex.Message, false);
                }
            }
            else
            {
                ClearPartes();
            }
        }

        private void CargarImagen()
        {
            string fileName = $"{TxtParte.Text}.jpg"; // número de parte
            string filePath = $"\\\\cgmxfile400\\Tracebility\\Images\\{fileName}"; // Ruta de la carpeta compartida

            if (File.Exists(filePath))
            {
                ImgParte.ImageUrl = $"~/Content/imgServidor/{fileName}"; // URL relativa para mostrar en el navegador
            }
            else
            {
                ImgParte.ImageUrl = "~/Content/imgServidor/no-imagen.png"; // Imagen de "No disponible"
            }
        }


        protected void BtnBorrarParte_Click(object sender, EventArgs e)
        {
            SQL sql = new SQL();
            sql.Base();
            LbErrors.Text = GridView1.SelectedRow.Cells[0].Text;

            // Obtenemos el número de parte desde la fila seleccionada
            string parte = GridView1.SelectedRow.Cells[0].Text;

            // Primero eliminamos la parte de la base de datos
            sql.AddParameter("@Parte", parte);
            sql.SpWeb_DelParte();

            // Verificar si hubo algún error
            LbErrorPartes.Text = sql.Errors;

            if (string.Compare(LbErrorPartes.Text, "") == 0)
            {
                // Recargar la grilla de partes
                CargaGridPartes();

                // Ocultar botones según sea necesario
                BtGuardaParte.Visible = true;
                BtnUpdateParte.Visible = false;
                BtnBorrarParte.Visible = false;

                // Limpiar los campos
                ClearPartes();

                //// Ruta de la imagen a eliminar
                //string rutaImagen = $@"C:\Users\bayer\Pictures\imgServidor\{parte}.jpg"; // Ajusta según la ruta de tu servidor

                //// Verificar si la imagen existe
                //if (File.Exists(rutaImagen))
                //{
                //    try
                //    {
                //        // Eliminar la imagen
                //        File.Delete(rutaImagen);
                //    }
                //    catch (Exception ex)
                //    {
                //        LbErrorPartes.Text = "Error al eliminar la imagen: " + ex.Message;
                //    }
                //}
            }
        }


        protected void DDOperaciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            OperacionCambia();
            CargaGridLimites();
        }

        private void OperacionCambia()
        {
            DDGeneroLim.Items.Clear();
            SQL sql1 = new SQL();
            sql1.Base();
            sql1.AddParameter("@operacion", DDOperaciones.SelectedValue.ToString());
            DDGeneroLim.DataSource = sql1.SpWeb_GetGeneros();
            DDGeneroLim.DataTextField = "Genero";
            DDGeneroLim.DataValueField = "Genero";
            DDGeneroLim.DataBind();
            DDGeneroLim.SelectedIndex = 0;

            //if (string.Equals(DDOperaciones.SelectedValue, "75"))
            //{
            //    //ListItem l = new ListItem("text", "value", true); l.Selected = true;
            //    ListItem li = new ListItem("PT", "PT", true);
            //    DDGeneroLim.Items.Add(li);
            //}
            //if (string.Equals(DDOperaciones.SelectedValue, "20"))
            //{
            //    //ListItem l = new ListItem("text", "value", true); l.Selected = true;
            //    ListItem li = new ListItem("C", "C", true);
            //    DDGeneroLim.Items.Add(li);
            //}
            //if (string.Equals(DDOperaciones.SelectedValue, "30") || string.Equals(DDOperaciones.SelectedValue, "35"))
            //{
            //    //ListItem l = new ListItem("text", "value", true); l.Selected = true;
            //    ListItem l = new ListItem("WG", "VWG", true);
            //    DDGeneroLim.Items.Add(l);
            //    ListItem l1 = new ListItem("WA", "VWA", true);
            //    DDGeneroLim.Items.Add(l1);
            //    ListItem l2 = new ListItem("MG", "VMG", true);
            //    DDGeneroLim.Items.Add(l2);
            //    ListItem l3 = new ListItem("MA", "VMA", true);
            //    DDGeneroLim.Items.Add(l3);
            //}
            //if (string.Equals(DDOperaciones.SelectedValue, "40") || string.Equals(DDOperaciones.SelectedValue, "50") || string.Equals(DDOperaciones.SelectedValue, "60") || string.Equals(DDOperaciones.SelectedValue, "65"))
            //{
            //    //ListItem l = new ListItem("text", "value", true); l.Selected = true;
            //    ListItem l = new ListItem("WG", "WG", true);
            //    DDGeneroLim.Items.Add(l);
            //    ListItem l1 = new ListItem("WA", "WA", true);
            //    DDGeneroLim.Items.Add(l1);
            //    ListItem l2 = new ListItem("MG", "MG", true);
            //    DDGeneroLim.Items.Add(l2);
            //    ListItem l3 = new ListItem("MA", "MA", true);
            //    DDGeneroLim.Items.Add(l3);
            //    ListItem l4 = new ListItem("VMG", "VMG", true);
            //    DDGeneroLim.Items.Add(l4);
            //}
            //if (string.Equals(DDOperaciones.SelectedValue, "51"))
            //{
            //    //ListItem l = new ListItem("text", "value", true); l.Selected = true;
            //    ListItem l = new ListItem("MA", "MA", true);
            //    DDGeneroLim.Items.Add(l);
            //    ListItem l1 = new ListItem("MG", "MG", true);
            //    DDGeneroLim.Items.Add(l1);
            //    ListItem l2 = new ListItem("VMA", "VMA", true);
            //    DDGeneroLim.Items.Add(l2);
            //    ListItem l3 = new ListItem("VWA", "VWA", true);
            //    DDGeneroLim.Items.Add(l3);
            //    ListItem l4 = new ListItem("VWG", "VWG", true);
            //    DDGeneroLim.Items.Add(l4);
            //    ListItem l5 = new ListItem("WA", "WA", true);
            //    DDGeneroLim.Items.Add(l5);
            //    ListItem l6 = new ListItem("WG", "WG", true);
            //    DDGeneroLim.Items.Add(l6);
            //}
            SQL sql = new SQL();
            sql.Base();
            sql.AddParameter("@Operacion", DDOperaciones.SelectedValue);

            DDdescLim.DataSource = sql.spWeb_GetLimitesXop();
            DDdescLim.DataTextField = ("Limite_desc").ToUpper();
            DDdescLim.DataValueField = "Limite_desc".ToUpper();
            DDdescLim.DataBind();

            //GridView3.DataSource = sql.spWeb_GetLimitesXop();
            //GridView3.DataBind();
        }

        protected void DDGeneroLim_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void TxtLimDec_TextChanged(object sender, EventArgs e)
        {
            if (string.Equals(TxtLimDec.Text.ToString(), ""))
            {
                TxtLimFrac.Text = "";
            }
            else
            {
                try
                {
                    if (string.Equals(DDOperaciones.SelectedValue, "20") || string.Equals(DDOperaciones.SelectedValue, "75") || string.Equals(DDdescLim.SelectedValue, "BALANCEO"))
                    {
                        if (string.Equals(DDOperaciones.SelectedValue, "75") || string.Equals(DDOperaciones.SelectedValue, "20"))
                            TxtLimFrac.Text = TxtLimDec.Text;
                        if (string.Equals(DDdescLim.SelectedValue, "BALANCEO"))
                        {
                            int valor = Convert.ToInt32(TxtLimDec.Text);
                            if (valor == 114)
                                TxtLimFrac.Text = "C2";
                            if (valor == 115)
                                TxtLimFrac.Text = "C3";
                            if (valor == 116)
                                TxtLimFrac.Text = "C4";
                            if (valor == 117)
                                TxtLimFrac.Text = "C5";
                            if (valor == 118)
                                TxtLimFrac.Text = "C6";
                            if (valor == 119)
                                TxtLimFrac.Text = "C7";
                            if (valor == 120)
                                TxtLimFrac.Text = "C8";
                            if (valor == 121)
                                TxtLimFrac.Text = "C9";
                            if (valor == 122)
                                TxtLimFrac.Text = "D0";
                            if (valor == 123)
                                TxtLimFrac.Text = "D1";
                            if (valor == 124)
                                TxtLimFrac.Text = "D2";
                            if (valor == 125)
                                TxtLimFrac.Text = "D3";
                            if (valor == 126)
                                TxtLimFrac.Text = "D4";
                            if (valor == 127)
                                TxtLimFrac.Text = "D5";
                            if (valor == 128)
                                TxtLimFrac.Text = "D6";
                        }
                    }
                    else
                    {
                        if (TxtLimDec.Text.Length <= 10)
                        {
                            SQL sql = new SQL();
                            sql.Base();
                            sql.AddParameter("@Qty", TxtLimDec.Text);
                            DataSet ds = sql.SpWeb_GetFraccion();
                            TxtLimFrac.Text = ds.Tables[0].Rows[0]["Fraccion"].ToString();
                        }
                        else
                        {
                            TxtLimFrac.Text = TxtLimDec.Text;
                        }
                    }                 
                }
                catch {
                    LbErrors.Text = "Debe ser numérico";
                }
            }
        }

        protected void BtnUpdateLimite_Click(object sender, EventArgs e)
        {
            SQL sql = new SQL();
            sql.Base();
            //LbErrors.Text = GridView1.SelectedRow.Cells[0].Text;
            if (CheckBox1.Checked)
                sql.AddParameter("@modelo", TxSKU.Text);
            else
                sql.AddParameter("@modelo", DDModelos0.SelectedValue);
            sql.AddParameter("@Operacion_id", DDOperaciones.SelectedValue);
            sql.AddParameter("@Limite_desc", DDdescLim.SelectedValue);
            sql.AddParameter("@genero", DDGeneroLim.SelectedValue);
            sql.AddParameter("@viejogenero", ViejoGenero);
            sql.AddParameter("@ViejaCabeza", ViejaCabeza);
            sql.AddParameter("@cabeza", TxtTipoLim.Text);
            sql.AddParameter("@decimal", TxtLimDec.Text);
            sql.AddParameter("@fraccion", TxtLimFrac.Text);
            
            sql.SpWeb_UpdtLimites();
            LbErrors.Text=sql.Errors;
            CargaGridLimites();
            BtGuardaLimites.Visible = true;
            BtnUpdateLimite.Visible = false;
            BtnBorrarLimite.Visible = false;
            ClearLimites();
        }

        protected void BtnBorrarLimite_Click(object sender, EventArgs e)
        {
            BorraLimite();
            ClearLimites();
        }

        protected void Button2_Click1(object sender, EventArgs e)
        {
            Response.Redirect("~/UploadLimits.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UploadParts.aspx");
        }

        protected void Button4_Click1(object sender, EventArgs e)
        {
            Response.Redirect("~/AltaProductoParte.aspx");
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AltaSets.aspx");
        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox1.Checked)
            {   DDModelos0.SelectedIndex = 0;
                DDModelos0.Enabled = false;            
                TxSKU.Enabled = true;
                RequiredFieldValidator11.Enabled = false;
                RequiredFieldValidator20.Enabled = true;
            }
            else {
                TxSKU.Text = "";
                DDModelos0.Enabled = true;
                TxSKU.Enabled = false;
                RequiredFieldValidator11.Enabled = true;
                RequiredFieldValidator20.Enabled = false;
            }
        }

        protected void TxSKU_TextChanged(object sender, EventArgs e)
        {
            CargaGridLimites();
        }

        protected void BtnBuscarLimites_Click(object sender, EventArgs e)
        {
            CargaGridLimites();
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            CargaGridModelos();
        }

        private void CargaGridModelos()
        {
            SQL sql = new SQL();
            sql.Base();
           
            sql.AddParameter("@Modelo", TxtModelo.Text);
           
            GvModelos.DataSource = sql.SpWeb_GetBusquedaModelos();
            GvModelos.DataBind();
            
        }
        
        protected void GvModelos_SelectedIndexChanged(object sender, EventArgs e)
        {
          TxtModelo.Text=GvModelos.SelectedRow.Cells[1].Text.Trim();
         TxtModeloDesc.Text = GvModelos.SelectedRow.Cells[2].Text.Trim();
         TxtModeloOr.Text = GvModelos.SelectedRow.Cells[3].Text.Trim();
         TxtModeloOrden.Text = GvModelos.SelectedRow.Cells[4].Text.Trim();
         BtnBorrarModelo.Visible = true;
        }

        protected void BtnBorrarModelo_Click(object sender, EventArgs e)
        {
               SQL sql = new SQL();
                       sql.Base();
                       sql.AddParameter("@modelo", TxtModelo.Text);
                       sql.SpWeb_DelModelos();
                       LbErrorModelos.Text = sql.Errors;
                       if (string.Compare(LbErrorModelos.Text, "") == 0)
                       {
                           CargaGridModelos();
                           BtnBorrarModelo.Visible = false;
                           TxtModelo.Text = "";
                           TxtModeloDesc.Text = "";
                           TxtModeloOr.Text = "";
                           TxtModeloOrden.Text = "";
                       } 
            
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            ClearLimites();
        }

        protected void Button8_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AltaProductoParteInd.aspx");
        }

        protected void Button9_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AltaSetsInd.aspx");
            
        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            SQL sql = new SQL();
            sql.Base();
            sql.AddParameter("@asociado", TextBox3.Text);
            sql.AddParameter("@pass", TextBox4.Text);
            sql.AddParameter("@op", "59");
            DataSet ds = sql.SpWeb_GetAsociados_Extensiones();
            LbErrors.Text = sql.Errors;
            if (LbErrors.Text == "" & (ds.Tables[0].Rows.Count != 0))
            {

                LbAsociado0.Text = ds.Tables[0].Rows[0][0].ToString();
                LbAsociado.Text = ds.Tables[0].Rows[0][1].ToString();
                TextBox3.Text = "";
                TextBox4.Text = "";
                LbErrors0.Text = "";
                Login.Visible = false;
                Panel1.Visible = true;
            }
            else
            {
                TextBox3.Text = "";
                TextBox4.Text = "";
                LbErrors0.Text = "Sin autorización";
            }
        }
    }
}