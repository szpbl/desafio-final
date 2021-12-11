const baseUrl = "https://localhost:44329/api/v1";

function authHeaders() {
  return { Authorization: `Bearer ${sessionStorage.getItem("accessToken")}` };
}

function isLoggedIn() {
  return !!sessionStorage.getItem("accessToken");
}

function login(email, password) {
  return fetchJson(`${baseUrl}/Auth/login`, {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify({ email, password }),
  }).then(
    (data) => {
      sessionStorage.setItem("accessToken", data.accessToken);
    },
    () => {
      sessionStorage.removeItem("accessToken");
      throw new Error("Falha no login. Verifique as credênciais e tente novamente.");
    }
  );
}

function fetchVoid(url, options) {
  return fetch(url, options).then((r) => {
    if (r.ok) {
      return;
    } else {
      throw new Error(r.statusText);
    }
  });
}

function fetchJson(url, options) {
  return fetch(url, options)
    .then((r) => {
      if (r.ok) {
        return r.json();
      } else {
        throw new Error(r.statusText);
      }
    })
    .then((json) => json.data);
}

function listBooks() {
  return fetchJson(`${baseUrl}/Books`, { headers: authHeaders() });
}

function listAuthors() {
  return fetchJson(`${baseUrl}/Authors`, { headers: authHeaders() });
}

function createBook(book) {
  return fetchJson(`${baseUrl}/Books`, {
    method: "POST",
    headers: { ...authHeaders(),"Content-Type": "application/json"},
    body: JSON.stringify(book),
  });
}

function removeBook(id) {
  return fetchVoid(`${baseUrl}/Books/${id}`, {
    method: "DELETE",
    headers: { ...authHeaders() }
  });
}

function updateBook(book) {
  return fetchJson(`${baseUrl}/Books/${book.id}`, {
    method: "PUT",
    headers: {...authHeaders(), "Content-Type": "application/json"},
    body: JSON.stringify(book),
  });
}