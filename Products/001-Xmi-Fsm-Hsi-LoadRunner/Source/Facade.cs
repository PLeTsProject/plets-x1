using System;
using Plets.Core.Uml;
using Plets.Core.FiniteStateMachine;

namespace Plets.Product.P001
{

	public class Facade
	{

		private UmlModel model;
		private FiniteStateMachine fsm;

		public Facade(){
	
			this.model = new UmlModel();
			this.fsm = new FiniteStateMachine("test prod fsm");
	
	
			//remove this piece of crap and add 
			//a decent UI
			this.LoadUmlFromFile();
			this.ConvertUmlModelToTaggedFsm();
			this.GenerateTestSequencesWithHsi();
			this.GenerateScriptsForLoadRunner();	
			this.ExecuteLoadRunner();
		}
	
		public void LoadUmlFromFile(){
			//add parser here and populate the model;
		}
	
		public void ConvertUmlModelToTaggedFsm(){
			//add convertor here
		}
	
		public void GenerateTestSequencesWithHsi(){
			//add hsi here
		}	
	
		public void GenerateScriptsForLoadRunner(){
			//add script gen here
		}
	
		public void ExecuteLoadRunner(){
			//add executor here
		}
	
		//add more for oracle and etc.
	}
}