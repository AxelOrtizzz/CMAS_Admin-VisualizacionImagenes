using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace CallawayWeb
{
    public class SQL:Base_Service

    {
        public DataSet SpWeb_SetMLPutters()
        {
            return ReadDS("SpWeb_SetMLPutters");
        }
        public DataSet SpWeb_SetML()
        {
            return ReadDS("SpWeb_SetML");
        }
        public DataSet SpWeb_GetProductividadSAPdetalle()
        {
            return ReadDS("SpWeb_GetProductividadSAPdetalle");
        }
        public DataSet SpWeb_GetProductividadSAP1()
        {
            return ReadDS("SpWeb_GetProductividadSAP");
        }
        public DataSet SpWeb_GetProductividadSAP()
        {
            return ReadDS("SpPrd_GetProductividadSAP");
        }

        public DataSet SpWeb_GetAsociadosXDia()
        {
            return ReadDS("SpWeb_GetAsociadosXDia");
           
        }
        public DataSet SpWeb_GetSAPFamilias()
        {
            return ReadDS("SpWeb_GetSAPFamilias");

        }
        public DataSet SpWeb_GetEstadoAsociados()
        {
            return ReadDS("SpWeb_GetEstadoAsociados");
           
        }
        public void spWeb_DelPadreHijo()
        {
            Write("spWeb_DelPadreHijo");
        }
        public DataSet SpWeb_GetSetsXpadre()
        {
            return ReadDS("SpWeb_GetSetsXpadre");
           
        }
        public void spWeb_DelProductoPartes()
        {
            Write("spWeb_DelProductoPartes");
        }
        public DataSet SpWeb_GetPartesXproducto()
        {
            return ReadDS("SpWeb_GetPartesXproducto");
           
        }

        public DataSet SpWeb_GetBusquedaModelos()
        {
            return ReadDS("SpWeb_GetBusquedaModelos");
           
        }

        public DataSet SpWeb_GetMedicionesyAjustes()
        {
            return ReadDS("SpWeb_GetMedicionesyAjustes");
           
        }
          public DataSet SpWeb_GetPruebas()
        {
            return ReadDS("SpWeb_GetPruebas");
           
        }
        public DataSet SpWeb_GetAjustes()
        {
            return ReadDS("SpWeb_GetAjustes");
           
        }

        public DataSet SpWeb_GetGeneros()
        {
            return ReadDS("SpWeb_GetGeneros");
           
        }
        
        public void SpWeb_DelModelos()
        {
            Write("SpWeb_DelModelos");
        }

        public void SpMat_SetRequi()
        {
            Write("SpWeb_SetModelo");
        }
        public void SpMat_SetPartes()
        {
            Write("SpWeb_SetPartes");
        }
        public void SpWebb_SetPartes2()
        {
            Write("SpWeb_SetPartes2");
        }
        public void SpWeb_SetAsociadoOperacion()
        {
            Write("SpWeb_SetAsociadoOperacion");
        }
        
        public void SpMat_SetLimites()
        {
            Write("SpWeb_SetLimites");
        }
        public void SpWeb_SetAsociado()
        {
            Write("SpWeb_SetAsociado");
        }
        
        public void SpWeb_DelParte()
        {
            Write("SpWeb_DelParte");
        }
        public void SpWeb_DelAsociado()
        {
            Write("SpWeb_DelAsociado");
        }
        
        public void SpWeb_DelLimite()
        {
            Write("SpWeb_DelLimite");
        }
        public void SpWeb_DelTolerancias()
        {
            Write("SpWeb_DelTolerancias");
        }

        public void SpWeb_UpdtCompensaciones()
        {
            Write("SpWeb_UpdtCompensaciones");
        }
        public DataSet SpWeb_GetModelos()
        {
            return ReadDS("SpWeb_GetModelos");
           
        }

        public DataSet SpWeb_GetOperacionAsociado()
        {
            return ReadDS("SpWeb_GetOperacionAsociado");

        }
        public DataSet SpWeb_GetLimites()
        {
            return ReadDS("SpWeb_GetLimites");

        }
        public DataSet SpWeb_GetOperacionesXarea()
        {
            return ReadDS("SpWeb_GetOperacionesXarea");

        }
        
        public DataSet SpWeb_GetPartes()
        {
            return ReadDS("SpWeb_GetPartes");

        }
        public DataSet SpWeb_GetAreas()
        {
            return ReadDS("SpWeb_GetAreas");
        }


        public DataSet SpWeb_GetPartePorParte()
        {
            return ReadDS("SpWeb_GetPartePorParte");

        }

        public DataSet SpWeb_GetAsociados()
        {
            return ReadDS("SpWeb_GetAsociados");

        }
        public DataSet SpWeb_GetMateriales()
        {
            return ReadDS("SpWeb_GetMateriales");

        }
        public DataSet SpWeb_GetOperaciones()
        {
            return ReadDS("SpWeb_GetOperaciones");

        }
        public DataSet SpWeb_GetLineas()
        {
            return ReadDS("SpWeb_GetLineas");

        }
        public DataSet SpWeb_GetContadores()
        {
            return ReadDS("SpWeb_GetContadores");

        }
        public DataSet spWeb_GetLimitesXmodelo()
        {
            return ReadDS("spWeb_GetLimitesXmodelo");
        }
        
        public DataSet spWeb_GetLimitesXop()
        {
            return ReadDS("spWeb_GetLimitesXop");
        }
        public void SpWeb_UpdtPartes()
        {
            Write("SpWeb_UpdtPartes");

        }
        public DataSet spWeb_GetOrdenResultados()
        {
            return ReadDS("spWeb_GetOrdenResultados");
        }

        public DataSet SpWeb_GetResultadosPruebas()
        {
            return ReadDS("SpWeb_GetResultadosPruebas");
        }

        public DataSet SpWeb_GetIndicadores()
        {
            return ReadDS("SpWeb_GetIndicadores");
        }

        public DataSet SpWeb_GetIndicadorTurno()
        {
            return ReadDS("SpWeb_GetIndicadorTurno");
        }
        public DataSet SpWeb_GetProduccionTurnoLinea()
        {
            return ReadDS("SpWeb_GetProduccionTurnoLinea");
        }
        public DataSet SpWeb_GetStdProduccion()
        {
            return ReadDS("SpWeb_GetStdProduccion");
        }
        public void SpWeb_UpdtLimites()
        {
            Write("SpWeb_UpdtLimites");
        }
        public DataSet SpWeb_GetRetrabajo()
        {
            return ReadDS("SpWeb_GetRetrabajo");
        }

        public DataSet spWeb_GetOrdenOperacionPiezas()
        {
            return ReadDS("spWeb_GetOrdenOperacionPiezas");
        }
       
        public void SpWeb_SetSAPProduccionAlta()
        {
            Write("SpWeb_SetSAPProduccionAlta");
        }
        public DataSet SpWeb_GetVerifyUser()
        {
            return ReadDS("SpWeb_GetVerifyUser");
        }
        public void SpWeb_UpdtSAPProduccionAlta()
        {
            Write("SpWeb_UpdtSAPProduccionAlta");
        }

        public DataSet SpWeb_GetSAPUPEH()
        {
            return ReadDS("SpWeb_GetSAPUPEH");
        }
        public void SpWeb_UpdtLogin()
        {
            Write("SpWeb_UpdtLogin");
        }

        public DataSet SpWeb_GetSAPProduccionAcumulados()
        {
            return ReadDS("SpWeb_GetSAPProduccionAcumulados");
        }
        public DataSet SpWeb_GetProduccionHR()
        {
            return ReadDS("SpWeb_GetProduccionHR");
        }

        public DataSet SpWeb_GetTurno()
        {
            return ReadDS("SpWeb_GetTurno");
        }
        public DataSet SpWeb_GetSAPFamiliaAcumulados()
        {
            return ReadDS("SpWeb_GetSAPFamiliaAcumulados");
        }
        public DataSet SpWeb_GetLineasActivas()
        {
            return ReadDS("SpWeb_GetLineasActivas");
        }
        public void SpWeb_SetMDTdata()
        {
            Write("SpWeb_SetMDTdata");
        }
        public DataSet SpWeb_GetMTDdata()
        {
            return ReadDS("SpWeb_GetMTDdata");
        }
        public DataSet SpWeb_GetTiemposPantallas()
        {
            return ReadDS("SpWeb_GetTiemposPantallas");
        }

        public DataSet SpWeb_GetReportAdmin1()
        {
            return ReadDS("SpWeb_GetReportAdmin1");
        }
        
        public void SpWeb_UpdtTiemposPantallas()
        {
            Write("SpWeb_UpdtTiemposPantallas");
        }
        public void SpWeb_UpdExtensiones()
        {
            Write("SpWeb_UpdExtensiones");
        }
        
        public void spWeb_SetLimitesMASIVOS()
        {
            Write("spWeb_SetLimitesMASIVOS");
        }
        public DataSet SpWeb_GetExistenciaModelo()
        {
            return ReadDS("SpWeb_GetExistenciaModelo");
        }
        public DataSet SpWeb_GetExistenciaPARTE()
        {
            return ReadDS("SpWeb_GetExistenciaPARTE");
        }
        public DataSet SpWeb_GetFraccion()
        {
            return ReadDS("SpWeb_GetFraccion");
        }
        
        public void spWeb_SetProductoPartes()
        {
            Write("spWeb_SetProductoPartes");
        }
        public DataSet SpWeb_GetExistenciaPADRE()
        {
            return ReadDS("SpWeb_GetExistenciaPADRE");
        }
        public void spWeb_SetSKUPADREHIJO()
        {
            Write("spWeb_SetSKUPADREHIJO");
        }
        public void SpWeb_SetTolerancia()
        {
            Write("SpWeb_SetTolerancia");
        }
        public void SpWeb_DelOperacionAsociado()
        {
            Write("SpWeb_DelOperacionAsociado");
        }
        
        public DataSet SpWeb_GetTolerancias()
        {
            return ReadDS("SpWeb_GetTolerancias");
        }
         public DataSet SpWeb_GetSKUexiste()
        {
            return ReadDS("SpWeb_GetSKUexiste");
        }
        public DataSet SpWeb_GetPartsImagesReport()
        {
            return ReadDS("SpWeb_GetPartsImagesReport");
        }
        public DataSet SpWeb_GetAsociadosOrden()
        {
            return ReadDS("SpWeb_GetAsociadosOrden");
        }
        public DataSet SpWeb_GetExtensiones()
        {
            return ReadDS("SpWeb_GetExtensiones");
        }
        public DataSet SpWeb_GetAsociados_Extensiones()
        {
            return ReadDS("SpWeb_GetAsociados_Extensiones");
        }
        public DataSet SpWeb_GetExtensiones1()
        {
            return ReadDS("SpWeb_GetExtensiones1");
        }
        
            public DataSet SpWeb_GetPorcentajesCaptura()
            {
            return ReadDS("SpWeb_GetPorcentajesCaptura");
            }
            public DataSet SpWeb_GetPorcentajesCalidad()
            {
                return ReadDS("SpWeb_GetPorcentajesCalidad");
            }
            public DataSet SpWeb_GetCapturados()
            {
                return ReadDS("SpWeb_GetCapturados");
            }
            public DataSet SpPrd_GetKiteadasSAP()
            {
                return ReadDS("SpPrd_GetKiteadasSAP");
            }
    }
}