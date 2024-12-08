const API_URL = "https://localhost:7127";

export const getTracks = async () => {
  const response = await fetch(`${API_URL}/api/tracks`, {
    headers: {
      Authorization: `Bearer ${localStorage.getItem("token")}`,
    },
  });

  if (!response.ok) {
    throw new Error("Ошибка загрузки треков");
  }

  return response.json();
};

export const addTrack = async (trackData) => {
  const response = await fetch(`${API_URL}/api/tracks`, {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
      Authorization: `Bearer ${localStorage.getItem("token")}`,
    },
    body: JSON.stringify(trackData),
  });

  if (!response.ok) {
    throw new Error("Ошибка добавления трека");
  }

  return response.json();
};
