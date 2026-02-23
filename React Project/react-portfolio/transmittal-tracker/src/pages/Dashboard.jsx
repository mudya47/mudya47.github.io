// src/pages/Dashboard.jsx
import { useState, useEffect, useMemo, useCallback } from "react";
import Toolbar from "../components/Toolbar";
import TransmittalTable from "../components/TransmittalTable";
import AddTransmittalModal from "../components/AddTransmittalModal";

const API_BASE = import.meta.env.VITE_API_URL;
const TRANS_URL = `${API_BASE}/api/transmittal`;

// helper: parse berbagai format tanggal jadi timestamp (ms)
function parseDateToTs(d) {
  if (!d) return null;
  if (d instanceof Date) return d.setHours(0, 0, 0, 0);
  const s = String(d);

  // ISO yyyy-MM-dd...
  const mIso = s.match(/^(\d{4})-(\d{2})-(\d{2})/);
  if (mIso) return new Date(`${mIso[1]}-${mIso[2]}-${mIso[3]}T00:00:00`).getTime();

  // dd/MM/yyyy
  const mDmY = s.match(/^(\d{2})\/(\d{2})\/(\d{4})$/);
  if (mDmY) return new Date(`${mDmY[3]}-${mDmY[2]}-${mDmY[1]}T00:00:00`).getTime();

  // dd-MM-yyyy
  const mDmY2 = s.match(/^(\d{2})-(\d{2})-(\d{4})$/);
  if (mDmY2) return new Date(`${mDmY2[3]}-${mDmY2[2]}-${mDmY2[1]}T00:00:00`).getTime();

  const t = new Date(s).getTime();
  return Number.isNaN(t) ? null : new Date(new Date(t).setHours(0, 0, 0, 0)).getTime();
}

export default function Dashboard() {
  const [raw, setRaw] = useState([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);

  const [page, setPage] = useState(1);
  const [pageSize] = useState(10);
  const [sortBy, setSortBy] = useState("date");
  const [sortDir, setSortDir] = useState("desc");
  const [query, setQuery] = useState({ search: "", start: "", end: "" });

  const [showModal, setShowModal] = useState(false);
  const [editData, setEditData] = useState(null);

  const fetchData = useCallback(async () => {
    try {
      setLoading(true);
      setError(null);
      const res = await fetch(TRANS_URL);
      if (!res.ok) throw new Error(`HTTP ${res.status}`);
      const arr = await res.json();

      const normalized = (Array.isArray(arr) ? arr : []).map((x) => ({
        ...x,
        receiver: x.receiver ?? x.recipient ?? "",
        dateTs: parseDateToTs(x.date),
      }));
      setRaw(normalized);
    } catch (e) {
      setError(e.message || "Failed to load");
    } finally {
      setLoading(false);
    }
  }, []);

  useEffect(() => { fetchData(); }, [fetchData]);

  const handleQueryChange = useCallback((patch) => {
    setQuery((prev) => ({ ...prev, ...patch }));
  }, []);

  const filtered = useMemo(() => {
    let a = raw;

    if (query.search) {
      const q = query.search.toLowerCase();
      a = a.filter((x) =>
        [x.transNo, x.jobNumber, x.sender, x.receiver]
          .map((v) => (v ?? "").toString().toLowerCase())
          .some((s) => s.includes(q))
      );
    }

    const toTs = (s) => (s ? new Date(`${s}T00:00:00`).getTime() : null);
    const startTs = toTs(query.start);
    const endTs = toTs(query.end);

    if (startTs != null) a = a.filter((x) => (x.dateTs ?? -Infinity) >= startTs);
    if (endTs != null) a = a.filter((x) => (x.dateTs ?? Infinity) <= endTs);

    return a;
  }, [raw, query]);

  useEffect(() => setPage(1), [query]);

  // >>> setelah modal sukses simpan (POST/PUT), refetch lalu tutup modal
  const handleSave = useCallback(async () => {
    await fetchData();
    setShowModal(false);
    setEditData(null);
    setPage(1); // opsional: balik ke page 1 biar entry baru/edited langsung kelihatan
  }, [fetchData]);

  const handleDelete = async (item) => {
    if (!item?.id) {
      alert("Cannot delete: missing id.");
      return;
    }
    if (!window.confirm(`Delete Transmittal ${item.transNo || item.id}?`)) return;

    const res = await fetch(`${TRANS_URL}/${encodeURIComponent(item.id)}`, { method: "DELETE" });
    if (!res.ok) {
      const text = await res.text().catch(() => "");
      alert(`Delete failed: HTTP ${res.status} ${text}`);
      return;
    }
    await fetchData();
  };

  return (
    <>
      <div className="mb-3 d-flex justify-content-between align-items-center">
        <h2 className="m-0">Dashboard</h2>
        <button
          className="btn btn-success"
          onClick={() => { setEditData(null); setShowModal(true); }}
        >
          + Add Transmittal
        </button>
      </div>

      <Toolbar onQueryChange={handleQueryChange} />

      <div className="mt-3">
        <TransmittalTable
          data={filtered}
          page={page}
          pageSize={pageSize}
          onPageChange={setPage}
          sortBy={sortBy}
          sortDir={sortDir}
          onSortChange={(k, dir) => { setSortBy(k); setSortDir(dir); }}
          isLoading={loading}
          error={error}
          onEdit={(item) => { setEditData(item); setShowModal(true); }}
          onDelete={handleDelete}
        />
      </div>

      {showModal && (
        <AddTransmittalModal
          onClose={() => { setShowModal(false); setEditData(null); }}
          onSave={handleSave}              // modal panggil ini setelah POST/PUT sukses
          initialData={editData}
          mode={editData ? "edit" : "add"}
        />
      )}
    </>
  );
}
