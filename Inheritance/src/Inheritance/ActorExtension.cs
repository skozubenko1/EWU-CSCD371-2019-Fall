using System;
using System.Collections.Generic;
using System.Text;

namespace Inheritance
{
    public static class ActorExtension
    {     
        public static string Speak(this Actor actor, bool WomenArePresent = false)
        {
            if (actor is null)
                throw new ArgumentNullException();

            switch (actor)
            {
                case Penny p:
                    return p.Speaking();
                case Sheldon s:
                    return s.Speaking();                    
                case Raj r:
                    if (WomenArePresent)
                        return r.Mumbling();
                    else
                        return r.Speaking();
                default:
                    throw new ArgumentNullException(nameof(actor));                   
            }
        }
     }

}
