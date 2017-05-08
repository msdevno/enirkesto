let franc = require("franc");
let langs = require("langs");

module.exports = {
    detect: (input) => {
        let iso639_2 = franc(input);
        // According to ISO-639-2/2T or 2B or 3 - NNO is "Ny-norsk" and NOB is Bokmål
        // Due to Franc not seeing some of the distinguishing differences it tends to default
        // to NNO. So we will basically look at both and call them NOB. 
        // Note: I know that this is very discriminating towards NNO practitioners, but 
        // for this we're going to do this.
        if( iso639_2 == "nno") iso639_2 = "nob";
        let language = langs.where("2", iso639_2);
        return language["1"];
    }
}