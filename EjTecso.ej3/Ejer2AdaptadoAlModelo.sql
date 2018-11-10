2-A
declare @idalumno2a int= 1; 
SELECT c.* 
FROM Inscripcion i
inner join Curso c on c.IDCurso = i.IDCurso
where i.IDAlumno = @idalumno2a and 
year(GETDATE()) =
year(c.FechaInicioCursada)
and i.IDEstado in (1,2)

--2-B
declare @asignatura varchar(100) = 'Matematica';
SELECT distinct a.* FROM Curso c
INNER JOIN Inscripcion i on c.IDCurso = i.IDCurso
INNER JOIN Alumno a on a.IDAlumno = i.IDAlumno
inner join Materia m on m.IDMateria= c.IDMateria
WHERE  m.Nombre like '%'+ @asignatura + '%' and i.IDEstado = 1;

--2-C
declare @idalumno2c int =4;

SELECT c.IDCurso, c.CupoMaximo, m.Nombre as Asignatura, d.Nombre
FROM Curso c
inner join Materia m on m.IDMateria = c.IDMateria
inner join Docente d on d.IDDocente= c.IDDocente
--INNER JOIN Inscripcion i on i.IDCurso = c.IDCurso
WHERE GETDATE() BETWEEN c.FechaInscripcionInicio and c.FechaInscripcionFin and 
isnull((SELECT SUM(1) FROM Inscripcion i1 where i1.IDCurso = c.IDCurso),0) < c.CupoMaximo and
c.IDCurso not in (SELECT i2.IDCurso from Inscripcion i2 where i2.IDAlumno = @idalumno2c)


--2-D 
--asumo que quiere los alumnos que recursaron una materia 3 veces:

SELECT distinct a.IDAlumno,a.Legajo, a.Nombre
FROM Inscripcion i 
inner join Curso c on c.IDCurso = i.IDCurso
inner join Materia m on m.IDMateria = c.IDMateria
INNER JOIN Alumno a on a.IDAlumno = i.IDAlumno
GROUP BY a.IDAlumno, a.Legajo, a.Legajo, a.Nombre, m.IDMateria
having sum(1) = 3

