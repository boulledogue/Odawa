/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Utils;

import java.io.FileWriter;

/**
 *
 * @author DCR
 */
public class LogManager {
    
    public void LogException(Exception ex) {
        try
        {
            String filename = System.getProperty("java.io.tmpdir") + "JavaExceptionLog.log";
            FileWriter fw = new FileWriter(filename,true);
            fw.write(ex + "\n");
            fw.close();
        }
        catch(Exception e)
        {
            //on ne fait rien, erreur dans le log ne peut pas être bloquant
        }
    } 
}
