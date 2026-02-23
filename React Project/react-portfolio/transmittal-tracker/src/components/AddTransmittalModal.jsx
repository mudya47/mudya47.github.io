import { useState, useEffect } from "react";

export default function AddTransmittalModal({ onClose, onSave, initialData = null, mode = "add" }) {
  const [form, setForm] = useState({
    transNo: "", jobNumber: "", title: "", date: "",
    sender: "", receiver: "", attachment: "" // <- URL yg tersimpan
  });
  const [file, setFile] = useState(null);     // <- file yang dipilih user
  const [preview, setPreview] = useState(""); // <- data URL buat preview
  const [submitting, setSubmitting] = useState(false);
  const [err, setErr] = useState("");

  useEffect(() => {
    if (initialData) {
      setForm({
        transNo: initialData.transNo || "",
        jobNumber: initialData.jobNumber || "",
        title: initialData.title || "",
        date: initialData.date ? initialData.date.split("T")[0] : "",
        sender: initialData.sender || "",
        receiver: initialData.receiver || initialData.recipient || "",
        attachment: initialData.attachment || "" // URL lama (jika ada)
      });
      setPreview(initialData.attachment || "");
    }
  }, [initialData]);

  const handleChange = (e) => {
    const { name, value } = e.target;
    setForm((p) => ({ ...p, [name]: value }));
  };

  const handleFile = (e) => {
    const f = e.target.files?.[0] || null;
    setFile(f);
    if (f) {
      const reader = new FileReader();
      reader.onload = () => setPreview(reader.result);
      reader.readAsDataURL(f);
    } else {
      setPreview("");
    }
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    setErr("");
    setSubmitting(true);
    try {
      const fd = new FormData();

      // === nama field harus sama dengan properti model di backend ===
      // Model: Id (int), JobNumber, Title, Date, Sender, Recipient, Attachment (server-set)
      if (mode === "edit" && initialData?.id != null) {
        fd.append("Id", String(initialData.id));   // penting buat Update [FromForm]
      }
      fd.append("JobNumber", form.jobNumber);
      fd.append("TransNo", form.transNo); 
      fd.append("Title", form.title);
      fd.append("Date", form.date);               // yyyy-MM-dd aman untuk model binder
      fd.append("Sender", form.sender);
      fd.append("Recipient", form.receiver);

      if (file) {
        fd.append("file", file);                  // harus key "file" (cocok dengan IFormFile file)
      }

      const url =
        mode === "edit"
          ? `http://10.47.24.193:5069/api/transmittal/${initialData.id}`
          : `http://10.47.24.193:5069/api/transmittal`;

      const method = mode === "edit" ? "PUT" : "POST";

      // ⚠️ JANGAN set Content-Type manual; biarkan browser set boundary
      const res = await fetch(url, { method, body: fd });
      if (!res.ok) {
        const t = await res.text().catch(()=>"");
        throw new Error(`${method} failed: HTTP ${res.status} ${t}`);
      }

      const saved = await res.json();
      onSave?.(saved);   // opsional: kalau parent masih butuh
      onClose?.();
    } catch (e) {
      console.error(e);
      setErr(e?.message || "Failed to save");
    } finally {
      setSubmitting(false);
    }
  };

  return (
    <>
      <div className="modal fade show d-block" tabIndex="-1" role="dialog" aria-modal="true">
        <div className="modal-dialog">
          <div className="modal-content">
            <div className="modal-header">
              <h5 className="modal-title">{mode === "edit" ? "Edit Transmittal" : "Add Transmittal"}</h5>
              <button type="button" className="btn-close" onClick={onClose} aria-label="Close" disabled={submitting} />
            </div>

            <form onSubmit={handleSubmit}>
              <div className="modal-body">
                {err && <div className="alert alert-danger">{err}</div>}

                {[
                  ["transNo","Trans-No"],
                  ["jobNumber","Job Number"],
                  ["title","Title"],
                  ["date","Date"],
                  ["sender","Sender"],
                  ["receiver","Receiver"],
                ].map(([key, label]) => (
                  <div className="mb-2" key={key}>
                    <label className="form-label">{label}</label>
                    <input
                      type={key === "date" ? "date" : "text"}
                      name={key}
                      className="form-control"
                      value={form[key] ?? ""}
                      onChange={handleChange}
                      required
                      disabled={mode === "edit" && key === "transNo"}
                    />
                  </div>
                ))}

                <div className="mb-2">
                  <label className="form-label">Attachment (scan/image)</label>
                  <input type="file" accept="image/*,application/pdf" className="form-control" onChange={handleFile} />
                  {/* {preview && (
                    <div className="mt-2">
                      {String(form.attachment || "").toLowerCase().endsWith(".pdf") || (file && file.type === "application/pdf")
                        ? <a href={form.attachment || preview} target="_blank" rel="noreferrer">Preview PDF</a>
                        : <img src={preview || form.attachment} alt="preview" style={{maxWidth:"100%", borderRadius:8, marginTop:8}} />
                      }
                    </div>
                  )} */}
                </div>
              </div>

              <div className="modal-footer">
                <button type="button" className="btn btn-secondary" onClick={onClose} disabled={submitting}>Cancel</button>
                <button type="submit" className="btn btn-success" disabled={submitting}>
                  {submitting ? "Saving..." : mode === "edit" ? "Update" : "Save"}
                </button>
              </div>
            </form>
          </div>
        </div>
      </div>
      <div className="modal-backdrop fade show"></div>
    </>
  );
}