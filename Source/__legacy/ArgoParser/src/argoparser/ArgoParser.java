/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package argoparser;

import Objects.UmlModel;
import OgmaOATSParser.Parser;
import Servico.ArgoUMLtoAstahXML;
import Servico.PopulateStructureModel;
import Servico.ReaderDocumentXML;
import javax.swing.JOptionPane;

public class ArgoParser
{

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args)
    {
        try
        {
            if (args.length > 0)
            {
                PopulateStructureModel psm = new PopulateStructureModel();
                Parser p = new Parser();
                ReaderDocumentXML reader = new ReaderDocumentXML();
                ArgoUMLtoAstahXML exporter = new ArgoUMLtoAstahXML();
                UmlModel model = null;
                String path = args[0].split("###")[0];
                String type = args[0].split("###")[1];
                //UmlModel model = psm.methodPopulateModel(reader.methodReaderXML("C:\\Users\\COC-7-01\\Desktop\\head\\__output\\plets\\Models\\ModeloTeste_Argo.xmi"));
                switch (type)
                {
                    case "ARGO":
                        model = psm.methodPopulateModel(reader.methodReaderXML(path));
                        break;
                    case "JAVA":
                        model = p.ReadScript(path);
                        break;
                }
                exporter.ToXmi(model);
            }
            else
            {
                JOptionPane.showMessageDialog(null, "Erro na execução do .JAR");
            }
        }
        catch (Exception e)
        {
            JOptionPane.showMessageDialog(null, "Erro na execução do .JAR" + e);
        }
    }
}
