using System.Collections.Generic;
int eleccion;
Dictionary<string, int> importePorCurso = new Dictionary<string, int>();
Console.WriteLine("0. Finalizar");
Console.WriteLine("1. Ingrese los importes de un curso");
eleccion = ingresarEntero("2. Ver estadísticas");
while (eleccion != 0){
    if (eleccion == 1){
        string nombre = IngresarString("Ingresar nombre del curso");
        int cantAlumnos = ingresarEntero("Ingresar cantidad de alumnos");
        importePorCurso.Add(nombre, ingresarImportes(cantAlumnos));
    }
    else if (eleccion == 2){
        verEstadisticas(importePorCurso);
    }
    Console.WriteLine("0. Finalizar");
    Console.WriteLine("1. Ingrese los importes de un curso");
    eleccion = ingresarEntero("2. Ver estadísticas");
}
string IngresarString(string texto){
    Console.WriteLine(texto);
    return Console.ReadLine();
}

int ingresarEntero(string texto){
    Console.WriteLine(texto);
    int numero;
    string lectura = Console.ReadLine();
    bool comprobacion = int.TryParse(lectura, out numero);
    if (!comprobacion)
    numero = ingresarEntero("Por favor. Ingresar un numero entero");
    return numero;
}

int ingresarImportes(int cantAlumnos){
    int suma = 0;
    for (int i = 1; i <= cantAlumnos; i++)
    {
        suma += ingresarEntero("Ingresar importe del alumno " + i);
    }
    return suma;
}

void verEstadisticas(Dictionary<string, int> importePorCurso){
    string cursoMayor = "";
    int mayor = int.MinValue, suma = 0;
    foreach (string clave in importePorCurso.Keys){
        if (importePorCurso[clave] > mayor){
            mayor = importePorCurso[clave];
            cursoMayor = clave;
        }
        suma += importePorCurso[clave];
    }
    Console.WriteLine("El curso que más plata puso fue " + cursoMayor);
    Console.WriteLine("El promedio de plata regalado por todos los cursos es " + suma / importePorCurso.Count());
    Console.WriteLine("La recaudación total entre todos los cursos es " + suma);
    Console.WriteLine("La cantidad de cursos que participan en el regalo es " + importePorCurso.Count());
}