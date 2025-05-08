using System.ComponentModel.DataAnnotations;

namespace ClinicaWebAPI_v2.Models
{
    public class PA_CITAS_ANIO
    {
        /*
         CREATE OR ALTER PROCEDURE PA_CITAS_ANIO
           @ANIO INT
           AS
           	SELECT C.nrocita, convert(varchar(10), C.fecha, 103) as fecha, 
           	       P.codpac, P.nompac,
           			C.pago, M.codmed, M.nommed, C.descrip
           	FROM Citas C INNER JOIN Pacientes P
           		ON C.codpac = P.codpac INNER JOIN Medicos M
           			ON C.codmed = M.codmed
           	WHERE YEAR(C.fecha) = @ANIO
           GO
         */
        [Key]
        public int nrocita { get; set; }
        public string fecha { get; set; } = "";
        public string codpac { get; set; } = "";
        public string nompac { get; set; } = "";
        public decimal pago { get; set; }
        public string codmed { get; set; } = "";
        public string nommed { get; set; } = "";
        public string descrip { get; set; } = "";
    }
}
