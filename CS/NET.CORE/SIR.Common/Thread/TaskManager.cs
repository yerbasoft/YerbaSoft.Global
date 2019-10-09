using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIR.Common.Thread
{
    public class TaskManager
    {
        /// <summary>
        /// Ejecuta una lista de Task (sin iniciar) controlando que se ejecuten de a una cantidad máxima a la vez
        /// </summary>
        /// <param name="all">Lista de tareas a ejecutar</param>
        /// <param name="together">Cantidad de procesos que correrán en simultáneo</param>
        public void ProcesarEnParalelo(Queue<Task> all, int together)
        {
            // Inicializo el Array de Tareas a procesar en simultáneo y las inicio
            var tasks = new Task[0];
            for (var i = 0; i < together; i++)
            {
                if (all.Count > 0)
                {
                    var task = all.Dequeue();
                    tasks = tasks.Concat(new Task[] { task }).ToArray();
                    task.Start();
                }
            }

            // Mientras haya pendientes de proceso, se espera a que termine algún proceso y se ejecuta el siguiente Task y se agrega al Array de Tareas
            while (all.Count > 0)
            {
                var index = Task.WaitAny(tasks);    // Espera a que termine cualquiera de las tareas en ejecución

                // Obtengo la siguiente tarea, la inicio y la agrego al array de tareas
                var task = all.Dequeue();
                task.Start();
                tasks = tasks.Where((p, i) => i != index).Concat(new Task[] { task }).ToArray();
            }

            // Una vez que no quedan pendientes, se debe esperar a que terminen todas las tareas que aún siguen corriendo
            if (tasks.Count() > 0)
                Task.WaitAll(tasks);

            return;
        }

        /// <summary>
        /// Ejecuta una lista de Task (sin iniciar) controlando que se ejecuten de a una cantidad máxima a la vez
        /// </summary>
        /// <param name="all">Lista de tareas a ejecutar</param>
        /// <param name="together">Cantidad de procesos que correrán en simultáneo</param>
        public IList<T> ProcesarEnParalelo<T>(Queue<Task<T>> all, int together)
        {
            // Inicializo el Array de Tareas a procesar en simultáneo y las inicio
            var tasks = new Task<T>[0];
            for (var i = 0; i < together; i++)
            {
                if (all.Count > 0)
                {
                    var task = all.Dequeue();
                    tasks = tasks.Concat(new Task<T>[] { task }).ToArray();
                    task.Start();
                }
            }

            var result = new List<T>();
            // Mientras haya pendientes de proceso, se espera a que termine algún proceso y se ejecuta el siguiente Task y se agrega al Array de Tareas
            while (all.Count > 0)
            {
                var index = Task.WaitAny(tasks);    // Espera a que termine cualquiera de las tareas en ejecución

                result.Add(tasks[index].Result);

                // Obtengo la siguiente tarea, la inicio y la agrego al array de tareas
                var task = all.Dequeue();
                task.Start();
                tasks = tasks.Where((p, i) => i != index).Concat(new Task<T>[] { task }).ToArray();
            }

            // Una vez que no quedan pendientes, se debe esperar a que terminen todas las tareas que aún siguen corriendo
            if (tasks.Count() > 0)
            {
                Task.WaitAll(tasks);
                result.AddRange(tasks.Select(p => p.Result));
            }

            return result;
        }
    }
}
