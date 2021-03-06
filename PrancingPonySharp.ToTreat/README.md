# About the implementation of ToTreat in this project

The idea of structure is to force you to deal with the exceptions of your functions. Because, trusting the programmer to deal with the exceptions is dangerous and should be avoided or have you never taken an exception without treatment in your application?]

**To solve this, simply return a Func or an Action to the data structure it will be encapsulated.**

Then, when using you will have to treat the exceptions according to what was passed.

`readonly struct ActionToTreat`

`readonly struct ActionToTreat<TE1>`

`readonly struct ActionToTreat<TE1, TE2>`

`readonly struct ActionToTreat<TE1, TE2, TE3>`

`readonly struct ActionToTreat<TE1, TE2, TE3, TE4>`

* TE is the type of exception

***or*** 

`readonly struct FuncToTreat<T>`

`readonly struct FuncToTrea<T, TE1>`

`readonly struct FuncToTrea<T, TE1, TE2>`

`readonly struct FuncToTrea<T, TE1, TE2, TE3>`

`readonly struct FuncToTrea<T, TE1, TE2, TE3, TE4>` 

* T is the type of return
* TE is the type of exception
 
 
> **By default you are always required to treat the default exception.**

The best place to be you use to learn about ToTreat is the [test folder of the ToTreat](https://github.com/eduardosilva218/PrancingPonySharp/tree/main/PrancingPonySharp.ToTreat.Test)

### But here is a standard example.

        >>> PokemonService.cs
        public FuncToTreat<Pokemon> GetPokemon(int id) =>
           return new FuncToTreat<Pokemon>(() => Repository.GetPokemon(id));

        >>> PokemonController.cs
        public Pokemon GetPokemon(int id) =>
            PokemonService.GetPokemon(id).RunOrFailure(exception => throw exception);

***or***

        >>> PokemonService.cs
        public ActionToTreat SavePokemon(Pokemon pokemon) =>
           return new ActionToTreat(() => Repository.SavePokemon(pokemon));

        >>> PokemonController.cs
        public void SavePokemon()
        {
            var pokemonToSave = new Pokemon { Name = "Pikachu" };
            PokemonService.SavePokemon(pokemonToSave).RunOrFailure(exception => throw exception);
        }
        
And you can pass four more exceptions that will force the programmer to deal with.
