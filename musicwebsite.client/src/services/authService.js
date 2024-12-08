const API_URL = "https://localhost:7127";

export const register = async (userData) => {
  const response = await fetch(`${API_URL}/api/auth/register`, {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(userData),
  });

  if (!response.ok) {
    throw new Error("Ошибка регистрации");
  }

  return response.json();
};

export const login = async (credentials) => {
  const response = await fetch(`${API_URL}/api/auth/login`, {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(credentials),
  });

  if (!response.ok) {
    throw new Error("Ошибка входа");
  }

  const data = await response.json();

  localStorage.setItem("token", data.token);

  return data;
};

export const logout = () => {
  localStorage.removeItem("token");
};
