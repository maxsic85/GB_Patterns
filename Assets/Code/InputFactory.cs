using UnityEngine;


namespace Max.Asteroid
{
   public sealed class InputFactory
    {
        IInput _input;
        PlayerData _data;
  
        public InputFactory(PlayerData data )
        { 
            GetInputFromPlayer(data.InputType);
            _data = data;
        }

        public IInput GetInputFromPlayer(InputType inputType)
        {
            _input = inputType switch
            {
                InputType.KEYBORD => new KeybordInput(_data),
                //TO DO Add mobile input
                InputType.MOBILE => new KeybordInput(_data),
            };
            return _input;
        }

      
    }
}
