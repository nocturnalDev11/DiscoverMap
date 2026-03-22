import { useEffect, useState } from "react";
import { MapContainer, TileLayer, Marker, Popup } from "react-leaflet";
import "leaflet/dist/leaflet.css";
import type { Pin } from "../types/Pin";
import { fetchPins } from "../services/pinService";
import L from "leaflet";

delete (L.Icon.Default.prototype as any)._getIconUrl;
L.Icon.Default.mergeOptions({
  iconRetinaUrl:
    "https://unpkg.com/leaflet@1.7.1/dist/images/marker-icon-2x.png",
  iconUrl: "https://unpkg.com/leaflet@1.7.1/dist/images/marker-icon.png",
  shadowUrl: "https://unpkg.com/leaflet@1.7.1/dist/images/marker-shadow.png",
});

const Map = () => {
  const [pins, setPins] = useState<Pin[]>([]);

  useEffect(() => {
    fetchPins().then(setPins);
  }, []);

  return (
    <MapContainer center={[14.5995, 120.9842]} zoom={13} style={{ height: "100vh", width: "100%" }}>
      <TileLayer
        attribution='&copy; OpenStreetMap contributors'
        url="https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png"
      />
      {pins.map((pin) => (
        <Marker key={pin.id} position={[pin.latitude, pin.longitude]}>
          <Popup>
            <strong>{pin.title}</strong>
            <br />
            {pin.description}
            <br />
            <em>#{pin.category}</em>
          </Popup>
        </Marker>
      ))}
    </MapContainer>
  );
};

export default Map;