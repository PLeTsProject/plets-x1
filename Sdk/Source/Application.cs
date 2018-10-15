using System;
using System.Collections.Generic;

namespace Plets.Sdk {
    public class Application {

		public static void Main(string[] args){
		
			Application app = new Application();
			app.loop();
		
		}
		
		private void loop(){
			while(true){
			
				//show options
				Console.WriteLine("Choose one from below:");
				Console.WriteLine("1 - Create a new component");
				Console.WriteLine("9 - Exit");
				Console.Write(">> ");
				
				int option = int.Parse(Console.ReadLine());
				
				switch(option){
					//exit
					case 9: return;
					
					//create new component
					case 1: this.createNewComponent();
						break;
				}
			
			}
		}
		
		private void createNewComponent(){
		
			//1 - ask for type (to set folder to deploy)
			
			//2 - ask for a namespace
			
			//3 - ask for dependencies if any
			
			//4 - create folder 
			
			//5 - create csproj file
		
		}
    }
}