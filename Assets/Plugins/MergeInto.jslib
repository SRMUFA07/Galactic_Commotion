mergeInto(LibraryManager.library, {
    Accrue:function(score,token,seconds){
        walletAddress = "";
        try {
            const ethereum = window.ethereum;
            walletAddress = ethereum.selectedAddress
          } catch (e) {
             alert(e)
          }
        const request = new XMLHttpRequest()
        request.open("GET",`https://segagame.club/api/game/accrue?score=${score}&token=${token}&seconds=${seconds}&walletAddress=${walletAddress}&game=7`)
        request.send()
    },
    
    GetAccounts:function(){
        try {
            const ethereum = window.ethereum;
            ethereum.request({ method: 'eth_requestAccounts' });
          } catch (e) {
             alert(e)
          }
    }
});