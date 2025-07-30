# LabWebAv10-MicroserviceSongMinimalAPIAndController

Este repositorio contiene dos microservicios desarrollados en .NET 8.0 que realizan operaciones CRUD sobre una base de datos SQL Server. Ambos acceden a la tabla `TBL_SONG`, pero siguen enfoques diferentes:

- `MicroserviceSongV5`: usa **API minimalista**.
- `MicroserviceControllerSongV5`: usa el **estilo basado en controladores** (MVC).


En la carpeta raíz levanta la base de datos con el siguiente comando:

```bash
docker compose up -d
```

---

## 🧪 Microservicio 1: `MicroserviceSongV5` (API Minimalista)

Este servicio utiliza el estilo de **API minimalista** de .NET 8.0 y permite realizar operaciones CRUD sobre `TBL_SONG`.

### 🔧 Ejecución:

```bash
cd MicroserviceSongV5
dotnet run
```

Se inicia en: `http://localhost:[puerto asignado por .NET]`

---

## 🧪 Microservicio 2: `MicroserviceControllerSongV5` (con Controladores)

Este servicio utiliza **controladores** (`Controllers`) y el patrón tradicional MVC para exponer los mismos endpoints CRUD sobre `TBL_SONG`.

### 🔧 Ejecución:

```bash
cd MicroserviceControllerSongV5
dotnet run
```

Se inicia en: `http://localhost:[puerto asignado por .NET]`

---

## 🔗 Cadena de conexión usada

Ambos microservicios usan la siguiente cadena de conexión:

```txt
Server=localhost,1433;Database=BDD_PoliMusic_Song;User Id=Admin_song;Password=Admin1_song_p@ssword;Encrypt=False;
```

---

## 📚 Dependencias importantes

- [.NET 8.0 SDK](https://dotnet.microsoft.com/)
- `Microsoft.EntityFrameworkCore.SqlServer`
- `Microsoft.EntityFrameworkCore.Tools`
- `Docker` (para SQL Server)

---

## ✨ Autor

Proyecto desarrollado por Marco Antonio Márquez Santos como práctica de microservicios y estilos de diseño de APIs REST en .NET 8.0.
