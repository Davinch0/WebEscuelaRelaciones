using System;
using WebEscuelaRelaciones.Models;

namespace WebEscuelaRelaciones.Models
{
    public enum Grado
    {
        A, B, C, D, F
    }
    public class Inscripcion
    {
        //Esta entidad como ID usa el patrón classnameID (InscripcionID) en lugar de ID por sí misma
        //aunque le podemos poner solo ID
        public int InscripcionID { get; set; }

        //La propiedad AlumnoID es una clave externa (FK - Foreign Key) y la propiedad de navegación correspondiente es Alumno
        //para establecer la relacion.
        public int AlumnoID { get; set; }

        //La propiedad CursoID es una clave externa (FK - Foreign Key) y la propiedad de navegación correspondiente es Curso
        //para establecer la relacion.
        public int CursoID { get; set; }

        //La propiedad Grado es una enum. El signo ? después de la declaración de tipo Grado indica que la propiedad Grado? admite valores null.
        //Un curso que sea null es diferente de un curso cero. null significa que no se conoce un curso o que todavía no se ha asignado.
        public Grado? Grado { get; set; }

        //Propiedades de navegación (Que son las que establece la relacion con las entidades Curso y Alumno)
        public Curso Curso { get; set; }
        public Alumno Alumno { get; set; }
    }
}
