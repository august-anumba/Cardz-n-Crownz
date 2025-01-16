using UnityEngine;
using Mirror;
using UnityEngine.SceneManagement;

public class Combat : NetworkBehaviour
{
    [Header("Entity")]
    public Entity entity;

    [Header("Health")]
    public int maxHealth = 30;

    [Command(ignoreAuthority = true)]
    public void CmdChangeMana(int amount)
    {
        // Increase mana by amount. If 3, increase by 3. If -3, reduce by 3.
        if (entity is Player) entity.GetComponent<Player>().mana += amount;
    }

    [Command(ignoreAuthority = true)]
    public void CmdChangeStrength(int amount)
    {
        // Increase mana by amount. If 3, increase by 3. If -3, reduce by 3.
        entity.strength += amount;
    }

    [Command(ignoreAuthority = true)]
    public void CmdChangeHealth(int amount)
    {
        // Increase health by amount. If 3, increase by 3. If -3, reduce by 3.
        entity.health += amount;
        if (entity.health <= 0) Destroy(entity.gameObject);
        if (Player.localPlayer.health <= 0) SceneManager.LoadScene(0);
    }

    //Chip
    [Command(ignoreAuthority = true)]
    public void CmdChangeHealthChip(int chipAmount)
    {
        // Decrease player health by amount. If 3, increase by 3. If -3, reduce by 3.
        entity = Player.localPlayer;
        entity.health += chipAmount;
        if (entity.health <= 0) SceneManager.LoadScene(0);
    }

    [Command(ignoreAuthority = true)]
    public void CmdIncreaseWaitTurn()
    {
        entity.waitTurn++;
    }
}
