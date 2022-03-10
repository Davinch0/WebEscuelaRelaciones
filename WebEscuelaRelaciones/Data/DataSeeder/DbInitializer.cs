using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using WebEscuelaRelaciones.Models;

namespace WebEscuelaRelaciones.Data
{
    public class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
           using (var context = new AcademiaContext(
               serviceProvider.GetRequiredService<
                   DbContextOptions<AcademiaContext>>()))

            {
                context.Database.EnsureCreated();

                // Look for any Estudiantes.
                if (context.Alumnos.Any())
                {
                    return;   // DB has been seeded
                }

                var alumnos = new Alumno[] // creamos un ARRAY de objetos Alumno
                {
                new Alumno{Nombre="Carson",Apellido="Alexander",FechaInscripcion=DateTime.Parse("2005-09-01")},
                new Alumno{Nombre="Meredith",Apellido="Alonso",FechaInscripcion=DateTime.Parse("2002-09-01")},
                new Alumno{Nombre="Arturo",Apellido="Anand",FechaInscripcion=DateTime.Parse("2003-09-01")},
                new Alumno{Nombre="Gytis",Apellido="Barzdukas",FechaInscripcion=DateTime.Parse("2002-09-01")},
                new Alumno{Nombre="Yan",Apellido="Li",FechaInscripcion=DateTime.Parse("2002-09-01")},
                new Alumno{Nombre="Peggy",Apellido="Justice",FechaInscripcion=DateTime.Parse("2001-09-01")},
                new Alumno{Nombre="Laura",Apellido="Norman",FechaInscripcion=DateTime.Parse("2003-09-01")},
                new Alumno{Nombre="Nino",Apellido="Olivetto",FechaInscripcion=DateTime.Parse("2005-09-01")}
                };

                //añade todos los objetos del array alumnos a la tabla Alumnos
                foreach (Alumno a in alumnos)
                {
                    context.Alumnos.Add(a); // AÑADE UN OBJETO Alumno a LA TABLA Alumnos
                }
                //guarda los cambios
                context.SaveChanges();



                //array de objetos Curso
                var cursos = new Curso[]
                {
                new Curso{CursoID=1050,Titulo="Chemistry",Creditos=3},
                new Curso{CursoID=4022,Titulo="Microeconomics",Creditos=3},
                new Curso{CursoID=4041,Titulo="Macroeconomics",Creditos=3},
                new Curso{CursoID=1045,Titulo="Calculus",Creditos=4},
                new Curso{CursoID=3141,Titulo="Trigonometry",Creditos=4},
                new Curso{CursoID=2021,Titulo="Composition",Creditos=3},
                new Curso{CursoID=2042,Titulo="Literature",Creditos=4}
                };
                //añade todos los objetos del array cursos a la tabla Cursos
                foreach (Curso c in cursos)
                {
                    context.Cursos.Add(c); // añade un objeto Curso a la tabla Cursos
                }
                context.SaveChanges(); // guarda los cambios




                //array de objetos Inscripcion
                var inscripciones = new Inscripcion[]
                {
                new Inscripcion{AlumnoID=1,CursoID=1050,Grado=Grado.A},
                new Inscripcion{AlumnoID=1,CursoID=4022,Grado=Grado.C},
                new Inscripcion{AlumnoID=1,CursoID=4041,Grado=Grado.B},
                new Inscripcion{AlumnoID=2,CursoID=1045,Grado=Grado.B},
                new Inscripcion{AlumnoID=2,CursoID=3141,Grado=Grado.F},
                new Inscripcion{AlumnoID=2,CursoID=2021,Grado=Grado.F},
                new Inscripcion{AlumnoID=3,CursoID=1050},
                new Inscripcion{AlumnoID=4,CursoID=1050},
                new Inscripcion{AlumnoID=4,CursoID=4022,Grado=Grado.F},
                new Inscripcion{AlumnoID=5,CursoID=4041,Grado=Grado.C},
                new Inscripcion{AlumnoID=6,CursoID=1045},
                new Inscripcion{AlumnoID=7,CursoID=3141,Grado=Grado.A},
                };
                //añade todos los objetos del array inscripciones a la tabla Inscripciones
                foreach (Inscripcion i in inscripciones)
                {
                    context.Inscripciones.Add(i); // añade un objeto Inscripcion a la tabla Inscripciones
                }
                context.SaveChanges(); // guarda los cambios
                
            }
        }
    }
}
