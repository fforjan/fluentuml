// See https://aka.ms/new-console-template for more information
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Reflection;
using FluentUml.Model;

namespace FluentUml.Generator;

 public class GeneratorApp {         
        public static void Main(string[] args)
        {        
            var catalog = new AggregateCatalog();

            // Adds all the parts found in the same assembly as the Program class.
            foreach(var entry in args) {
                var assembly = Assembly.LoadFile(Path.GetFullPath(entry));
                catalog.Catalogs.Add(new AssemblyCatalog(assembly));
            }

            catalog.Catalogs.Add(new AssemblyCatalog(Assembly.GetCallingAssembly()));
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(ExcelGenerator.Generator).Assembly));
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(PlantUmlGenerator.Generator).Assembly));
            catalog.Catalogs.Add(new AssemblyCatalog(Assembly.GetCallingAssembly()));
            // Create the CompositionContainer with the parts in the catalog.
            var container = new CompositionContainer(catalog);

            var generators = container.GetExportedValues<IGenerator>();
            var diagrams = container.GetExportedValues<DiagramBase>();

            foreach(var diagram in diagrams) {
                diagram.Describe();
                foreach(var generator in generators) {
                    generator.Generate(diagram);
                }
            }                        
        }
    }
