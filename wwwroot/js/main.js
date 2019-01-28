//var config = {
//    type: Phaser.AUTO,
//    width: 1920,
//    height: 1080,
//    physics: {
//        default: 'arcade',
//        arcade: {
//            gravity: { y: 200 }
//        }
//    },
//    scene: {
//        preload: preload,
//        create: create
//    }
//};
//var game = new Phaser.Game(config);
//function preload() {

//    //ได้แล้ววว ต้องใช้ .. นำหน้าก่อน
//    this.load.image('background', '../assets/GU_Game/img/PNG/backgroud/pcbackgroud-day.png');

    
//    this.load.image('trees', '../assets/GU_Game/img/PNG/tree/tree-1.png');
//    this.load.image('coin', '../assets/GU_Game/img/PNG/coin/leaf-coin.png');
    
    
//}
//function create() {
//    //this.add.image(400, 300, 'background');
//    this.add.image(400, 300, 'background');
//    this.add.image(600, 300, 'trees').setScale(0.5);
//    //this.add.image(400, 300, 'coin').setScale(0.1);


//    //var particles = this.add.particles('trees');
//    //var emitter = particles.createEmitter({
//    //    speed: 100,
//    //    scale: { start: 1, end: 0 },
//    //    blendMode: 'ADD'
//    //});

//    var coin = this.physics.add.image(400, 100, 'coin').setScale(0.1);
//    coin.setVelocity(300, 500);
//    coin.setBounce(1, 1);
//    coin.setCollideWorldBounds(true);
    
    
//}