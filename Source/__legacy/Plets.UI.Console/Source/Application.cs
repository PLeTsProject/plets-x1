//#define PL_FUNCTIONAL_TESTING
//#define PL_PERFORMANCE_TESTING -- Não foi coberta por nenhuma configuração de solution
//#define PL_DFS
//#define PL_HSI
//#define PL_WP -- Não foi coberta por nenhuma configuração de solution
//#define PL_GRAPH
//#define PL_FSM
//#define PL_LR -- Não foi coberta por nenhuma configuração de solution
//#define PL_OATS
//#define PL_MTM
//#define PL_XMI

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using System.Xml;
using Plets.Core.ControlStructure;
using Plets.Core.ControlUnit;
using Microsoft.Win32;

namespace Plets.UI.Console{

    public class Application{
    
        public enum ErrorLevel { Critical, Warning, Message, Green }

		
        private ControlUnit control;
        private String filename;

        public Application(){
        	this.Run();
        }
        
        public void Run(){
        
        	//step 1: parsing
        	Console.WriteLine("File to be parsed: ");
        	filename = Console.ReadLine();
        	
        	//step 2: test case generation
			#if PL_OATS
            control = new ControlUnit(StructureType.OATS);
            type = StructureType.OATS;
			#endif
			#if PL_JUNIT
            control = new ControlUnit.ControlUnit(StructureType.DFS_TCC);
            type = StructureType.DFS_TCC;
			#endif
			#if PL_DFS
            control = new ControlUnit.ControlUnit(StructureType.DFS);
            type = StructureType.DFS;
			#endif
			#if PL_HSI
            control = new ControlUnit.ControlUnit(StructureType.HSI);
            type = StructureType.HSI;
			#endif
			#if PL_WP
            control = new ControlUnit.ControlUnit(StructureType.Wp);
            type = StructureType.Wp;
			#endif
            
            //TODO: set the proper parser type.
            //Friendly note: Usa reflection, pelo amor de deus. Essa coisa
            //de ficar passando string como parâmetro pra fazer switch depois
            //é feio, ineficiente e ainda deixa brecha pra qualquer estagiário
            //passar o parâmetro errado e fazer a gente debugar estupidez.
            control.LoadModelingStructure(dialog.FileName, "");            
            
            //step 2a: validation
            //TODO: esse step quem tem que fazer eh a geração do modelo formal, que 
            //deve checar se o que foi carregado do arquivo tem as caracteristicas 
            //que precisa pra fazer a transformação. Se tiver que dar pau lá na
            //frente, que dê. Pra isso existe tratamento de exceção. Se usar direitinho
            //dá pra fazer tracking do erro sem precisar parir um filho.
            
        	//step 3: script generation
        	control.GenerateSequence(type);
        	
        	//step 4: execution
        	
        }
    }
}