// ======================================================================================================================================
// SimplePend.cs    Defines a class for simulating a simple pendulum
// ======================================================================================================================================
using System;

namespace Sim
{
    public class SimplePend
    {
        private double len = 1.1;    //pendulum length
        private double g = 9.81;     // gravitational field strength
        
        int n = 2;                   // number of states
        private double[] x;          // array of states
        private double[] f;          // right side of equation evaluated
        // private double [] y;         // holds different k values
        // private double [] z;         // updates with time step and stores new value
        //----------------------------------------------------------------------------------------------------
        // constructor
        //----------------------------------------------------------------------------------------------------
        public SimplePend() 
        {
            x = new double[n];
            f = new double[n];
            // y = new double[4];
            // z = new double[n];

            x[0] = 1.0;     // sets first entry of x array
            x[1] = 0.0;     // sets second entry of x array
        }

        //----------------------------------------------------------------------------------------------------
        // step: perform one integration step via Euler's Method
        //       Soon, it will implement RK4
        //----------------------------------------------------------------------------------------------------
        public void step(double dt)
        {

            // Eulers Method
            rhsFunc(x,f);
            int i;
            for(i=0;i<n;++i) 
            {
                x[i] = x[i] + f[i] * dt;
            }

            // RK4 Method
            // i = 0;
            // while i < n
            // {
            //     y[0] = rhsFunc(x[i],f[i]);
            //     z = x[i] + y[0] * 0.5 *dt;
            //     y[1] = rhsFunc(x[i], f[i] + 0.5 * dt);
            //     z = x[i] + y[1] * 0.5 * dt;
            //     y[2] = rhsFunc(x[i], f[i] + 0.5 * dt);
            //     z = x[i] + y[2] * dt;
            //     y[3] = rhsFunc(x[i], f[i] + dt);
            //     x[i+1] = x[i] + (0.1667 * y[0] + 0.3333 * y[1] + 0.3333 * y[2] + 0.1667 * y[3])*dt;

            //     i += 1;
            // }
        
        }

        //----------------------------------------------------------------------------------------------------
        // rhsFunc: function to calculate rhs of pendulum ODEs
        //----------------------------------------------------------------------------------------------------
        
        public void rhsFunc(double[] st, double[] ff) 
        {
            ff[0] = st[1];
            ff[1] = -g/len * Math.Sin(st[0]);
        }

        //----------------------------------------------------------------------------------------------------
        // Getters and setters
        //----------------------------------------------------------------------------------------------------
        public double L 
        {
            get {return(len);}

            set 
            {
                if(value > 0.0)
                    len = value;
            }
        }

        public double G   // fix indents for G
        {
            get {return(g);}

            set 
            {
                if(value >= 0.0)
                    len = value;
            }
        }

        public double theta
        {
            get {return x[0];}

            set {x[0] = value;}
        }

        public double thetaDot
        {
            get {return x[1];}

            set {x[1] = value;}
        }
    }

}