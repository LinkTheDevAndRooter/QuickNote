# QuickNote

Utilidad ligera de escritorio para Windows con interfaz gráfica (Windows Forms) escrita en C# y compilada directamente con `csc.exe` como ejecutable independiente.

## Características

- **Interfaz gráfica limpia:** Abre directamente una ventana sin consola de fondo (`/target:winexe`).
- **Guardado rápido:** Agrega notas con marca de fecha y hora presionando **Enter** o haciendo clic en **Guardar**.
- **Historial visible:** Consulta todas tus notas guardadas desde la misma ventana.
- **Borrado seguro:** Opción para limpiar el historial con confirmación previa.
- **Ejecutable portátil:** Funciona como un `.exe` independiente sin requerir instalación compleja.

## Almacenamiento de notas

Las notas se guardan automáticamente en texto plano en la carpeta Documentos del usuario:

```text
C:\Users\user\Documents\QuickNote\notas.txt
