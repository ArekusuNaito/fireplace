# fireplace
A Minimal Card Game - #PullUpAChair

~ A minimal card game that comes to Life thank's to Hearthstone! 🃏

This is my programming style, I really enjoy clean code.
If your code doesn't need comments, then you will make it more mainteneable for others 😊
Take a look:

```csharp
			if(this.HasMinions)
			{	
				var opponent = Game.Opponent;
				var myMinion = this.board.MostPowerfulMinion;
				if(opponent.HasNoMinions)
				{
					opponent.TakeDamage(myMinion.attack);
				}
				else
				{
					var opponentMinion = Game.Opponent.board.MostHealthyMinion;
					//Cross attack!
					myMinion.TakeDamage(opponentMinion.attack);
					opponentMinion.TakeDamage(myMinion.attack);					
					if(myMinion.Died)
					{
						
						this.board.Remove(myMinion);
						this.boardUI.Remove(myMinion);
						Debug.Log($"{this.name}'s {myMinion.Name} died 😢");
					}
					if(opponentMinion.Died)
					{
						
						opponent.board.Remove(opponentMinion);
						opponent.boardUI.Remove(opponentMinion);
						Debug.Log($"{opponent.name}'s {opponentMinion.Name} died 😢");
					}
				}
			}

```