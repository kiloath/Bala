use bevy::prelude::*;
use rumqttc::{self, AsyncClient, MqttOptions, QoS, Transport};
use std::{error::Error, time::Duration};
use tokio::{task, time};

#[tokio::main(worker_threads = 1)]
async fn main() -> Result<(), Box<dyn Error>> {
    // App::new().add_plugins(DefaultPlugins).run();
    websocket_init().await
}

// #[tokio::main(worker_threads = 1)]
async fn websocket_init() -> Result<(), Box<dyn Error>> {
    //pretty_env_logger::init();

    // port parameter is ignored when scheme is websocket
    let mut mqttoptions = MqttOptions::new("clientId-aSziq39Bp3", "ws://127.0.0.1:8083/mqtt", 8000);
    mqttoptions.set_transport(Transport::Ws);
    mqttoptions.set_keep_alive(Duration::from_secs(60));

    let (client, mut eventloop) = AsyncClient::new(mqttoptions, 10);
    task::spawn(async move {
        requests(client).await;
        time::sleep(Duration::from_secs(3)).await;
    });

    loop {
        let event = eventloop.poll().await;
        match event {
            Ok(notif) => {
                println!("Event = {notif:?}");
            }
            Err(err) => {
                println!("Error = {err:?}");
                return Ok(());
            }
        }
    }
}

async fn requests(client: AsyncClient) {
    client.subscribe("hello/#", QoS::AtMostOnce).await.unwrap();

    for i in 1..=10 {
        client
            .publish("hello/world", QoS::ExactlyOnce, false, vec![1; i])
            .await
            .unwrap();

        time::sleep(Duration::from_secs(1)).await;
    }

    time::sleep(Duration::from_secs(120)).await;
}
