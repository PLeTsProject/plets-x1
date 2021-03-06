using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml;
using Lesse.Core.ControlAndConversionStructures;
using Lesse.Core.Interfaces;
using Lesse.Modeling.Uml;

namespace Lesse.OATS.OgmaJParser {
    public class OgmaJ : Parser {
        private List<GeneralUseStructure> listModelingStructure;

        #region Constructor
        public OgmaJ () {
            listModelingStructure = new List<GeneralUseStructure> ();
        }
        #endregion

        #region Public Methods
        public override StructureCollection ParserMethod (String path, ref String name, Tuple<String, Object>[] args) {
            StructureCollection model = new StructureCollection ();
            XmlDocument document = new XmlDocument ();

            CleanFile (ref path);

            ProcessStartInfo startInfo = new ProcessStartInfo ("ArgoParser\\ArgoParser.jar");

            //CHANGED BY GILIARDI - using an adapted version from the original ArgoParser (only need to specify the xmi path)
            //startInfo.Arguments = path + "###JAVA";
            startInfo.Arguments = "\"" + path + "\"";
            Process p = Process.GetProcessById (Process.Start (startInfo).Id);

            //wait until the process ends
            while (!p.HasExited);
            String tempPath = System.IO.Path.GetTempPath ();
            string partialName = "IntermediateFile";

            DirectoryInfo auxDirectory = new DirectoryInfo (tempPath);
            FileInfo[] filesInDir = auxDirectory.GetFiles (partialName + "*.xml");

            if (filesInDir.FirstOrDefault () == null) {
                throw new Exception ("Houve algum problema com o ArgoParser. Nenhum arquivo foi gerado");
            }

            document.Load (filesInDir.FirstOrDefault ().FullName);
            UmlModel model_aux = FromXmi (document, ref name);
            listModelingStructure.Add (model_aux);
            model.listGeneralStructure.AddRange (listModelingStructure);
            File.Delete (filesInDir.FirstOrDefault ().FullName);

            return model;
        }
        #endregion

        #region Private Methods
        private UmlModel FromXmi (XmlDocument doc, ref String name) {
            UmlModel model = null;
            XmlNodeList modelQuery = doc.SelectNodes ("//Objects.UmlModel");
            foreach (XmlNode modelNode in modelQuery) {
                model = new UmlModel ();
                model.Id = modelNode.Attributes["id"].Value;
                model.Name = modelNode.Attributes["name"].Value;
                name = model.Name;
            }

            #region UseCaseDiagram
            XmlNodeList ucDiagramQuery = doc.SelectNodes ("//Diagrams.UmlUseCaseDiagram");
            foreach (XmlNode ucDiagram in ucDiagramQuery) {
                UmlUseCaseDiagram umlUseCaseDiagram = new UmlUseCaseDiagram ();
                umlUseCaseDiagram.Name = ucDiagram.Attributes["name"].Value;
                umlUseCaseDiagram.Id = ucDiagram.Attributes["id"].Value;
                #region Actor
                foreach (XmlNode actorNode in ucDiagram.SelectNodes ("//Diagrams.UmlUseCaseDiagram[@id='" + umlUseCaseDiagram.Id + "']//Objects.UmlActor")) {
                    UmlActor element = new UmlActor ();
                    element.Id = actorNode.Attributes["id"].Value;
                    element.Name = actorNode.Attributes["name"].Value;

                    foreach (XmlNode tag in ucDiagram.SelectNodes ("//Diagrams.UmlUseCaseDiagram[@id='" + umlUseCaseDiagram.Id + "']//Objects.UmlActor[@id='" + element.Id + "']//TAG")) {
                        String key = tag.Attributes["tagName"].Value.ToUpper ();
                        String value = tag.Attributes["tagValue"].Value;
                        element.SetTaggedValue (key, value);
                    }
                    umlUseCaseDiagram.UmlObjects.Add (element);
                }
                #endregion
                #region UseCase
                foreach (XmlNode ucNode in ucDiagram.SelectNodes ("//Diagrams.UmlUseCaseDiagram[@id='" + umlUseCaseDiagram.Id + "']//Objects.UmlUseCase")) {
                    UmlUseCase element = new UmlUseCase ();
                    element.Id = ucNode.Attributes["id"].Value;
                    element.Name = ucNode.Attributes["name"].Value;
                    umlUseCaseDiagram.UmlObjects.Add (element);
                }
                #endregion
                #region Association
                foreach (XmlNode associationNode in ucDiagram.SelectNodes ("//Diagrams.UmlUseCaseDiagram[@id='" + umlUseCaseDiagram.Id + "']//Objects.UmlAssociation")) {
                    UmlAssociation element = new UmlAssociation ();
                    element.Id = associationNode.Attributes["id"].Value;
                    UmlElement end1 = SearchUseCaseDiagramElement (associationNode.Attributes["end1Id"].Value, umlUseCaseDiagram);
                    UmlElement end2 = SearchUseCaseDiagramElement (associationNode.Attributes["end2Id"].Value, umlUseCaseDiagram);
                    element.End1 = end1;
                    element.End2 = end2;
                    umlUseCaseDiagram.UmlObjects.Add (element);
                }
                #endregion
                model.AddDiagram (umlUseCaseDiagram);
            }
            #endregion
            #region ActivityDiagram
            XmlNodeList actDiagramQuery = doc.SelectNodes ("//Diagrams.UmlActivityDiagram");
            foreach (XmlNode actDiagram in actDiagramQuery) {
                UmlActivityDiagram umlActivityDiagram = new UmlActivityDiagram (actDiagram.Attributes["name"].Value);
                umlActivityDiagram.Id = actDiagram.Attributes["id"].Value;
                #region State Initial
                foreach (XmlNode initialNode in actDiagram.SelectNodes ("//Diagrams.UmlActivityDiagram[@id='" + umlActivityDiagram.Id + "']//Objects.UmlInitialState")) {
                    UmlInitialState element = new UmlInitialState ();
                    element.Id = initialNode.Attributes["id"].Value;
                    element.Name = initialNode.Attributes["name"].Value;
                    umlActivityDiagram.UmlObjects.Add (element);
                }
                #endregion
                #region Action State
                foreach (XmlNode actionStateNode in actDiagram.SelectNodes ("//Diagrams.UmlActivityDiagram[@id='" + umlActivityDiagram.Id + "']//Objects.UmlActionState")) {
                    UmlActionState element = new UmlActionState ();
                    element.Id = actionStateNode.Attributes["id"].Value;
                    element.Name = actionStateNode.Attributes["name"].Value;
                    umlActivityDiagram.UmlObjects.Add (element);
                }
                #endregion
                #region State Final
                foreach (XmlNode finalNode in actDiagram.SelectNodes ("//Diagrams.UmlActivityDiagram[@id='" + umlActivityDiagram.Id + "']//Objects.UmlFinalState")) {
                    UmlFinalState element = new UmlFinalState ();
                    element.Id = finalNode.Attributes["id"].Value;
                    element.Name = finalNode.Attributes["name"].Value;
                    umlActivityDiagram.UmlObjects.Add (element);
                }
                #endregion
                #region Fork
                foreach (XmlNode forkNode in actDiagram.SelectNodes ("//Diagrams.UmlActivityDiagram[@id='" + umlActivityDiagram.Id + "']//Objects.UmlFork")) {
                    UmlFork element = new UmlFork ();
                    element.Id = forkNode.Attributes["id"].Value;
                    element.Name = forkNode.Attributes["name"].Value;
                    umlActivityDiagram.UmlObjects.Add (element);
                }
                #endregion
                #region Join
                foreach (XmlNode joinNode in actDiagram.SelectNodes ("//Diagrams.UmlActivityDiagram[@id='" + umlActivityDiagram.Id + "']//Objects.UmlJoin")) {
                    UmlJoin element = new UmlJoin ();
                    element.Id = joinNode.Attributes["id"].Value;
                    element.Name = joinNode.Attributes["name"].Value;
                    umlActivityDiagram.UmlObjects.Add (element);
                }
                #endregion
                #region Decision
                foreach (XmlNode decisionNode in actDiagram.SelectNodes ("//Diagrams.UmlActivityDiagram[@id='" + umlActivityDiagram.Id + "']//Objects.UmlDecision")) {
                    UmlDecision element = new UmlDecision ();
                    element.Id = decisionNode.Attributes["id"].Value;
                    element.Name = decisionNode.Attributes["name"].Value;
                    umlActivityDiagram.UmlObjects.Add (element);
                }
                #endregion
                #region Transition
                foreach (XmlNode transitionNode in actDiagram.SelectNodes ("//Diagrams.UmlActivityDiagram[@id='" + umlActivityDiagram.Id + "']//Objects.UmlTransition")) {
                    UmlTransition element = new UmlTransition ();
                    UmlActionState actSource = SearchActivityDiagramElement (transitionNode.Attributes["stateSourceId"].Value, umlActivityDiagram);
                    UmlActionState actTarget = SearchActivityDiagramElement (transitionNode.Attributes["stateTargetId"].Value, umlActivityDiagram);
                    element.Id = transitionNode.Attributes["id"].Value;
                    element.Source = actSource;
                    element.Target = actTarget;
                    //Get TAG
                    foreach (XmlNode tag in actDiagram.SelectNodes ("//Diagrams.UmlActivityDiagram[@id='" + umlActivityDiagram.Id + "']//Objects.UmlTransition[@id='" + element.Id + "']//TAG")) {
                        String key = tag.Attributes["tagName"].Value.ToUpper ();
                        String value = tag.Attributes["tagValue"].Value;
                        element.SetTaggedValue (key, value);
                    }
                    umlActivityDiagram.UmlObjects.Add (element);
                }
                #endregion
                model.AddDiagram (umlActivityDiagram);
            }
            #endregion
            return model;
        }

        private UmlElement SearchUseCaseDiagramElement (string id, UmlUseCaseDiagram umlUseCaseDiagram) {
            foreach (UmlElement element in umlUseCaseDiagram.UmlObjects) {
                if (element.Id.Equals (id)) {
                    return element;
                }
            }
            return null;
        }

        private UmlActionState SearchActivityDiagramElement (string id, UmlActivityDiagram umlActivityDiagram) {
            foreach (UmlActionState act in umlActivityDiagram.UmlObjects.OfType<UmlActionState> ()) {
                if (act.Id.Equals (id)) {
                    return act;
                }
            }
            return null;
        }

        /*
        Remove all non utf-8 chars from file. Needed because the ArgoParser can't parse those chars.
        */
        private void CleanFile (ref string path) {
            string cleaned = Regex.Replace (File.ReadAllText (path), @"[^\u0020-\u007E]", "");
            path = System.IO.Path.GetTempPath () + "\\OGMJAtemfile.java";

            File.WriteAllText (path, cleaned);
        }
        #endregion
    }
}